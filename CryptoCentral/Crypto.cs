using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIAccessTEST01
{
    public partial class Crypto : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        public Crypto()
        {
            InitializeComponent();
        }

        //Creating Varaibles For Moving Form.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Creating Lists for JSON.
        List<MarketCap> Coins;
        List<MarketCap> CoinsDetailed;

        //Creating public varaibles.
        string CURRENCY;

        //Storing Json output as a string.
        string jsonString; 

        //Custom Coin inputs as Symbols eg "BTC".
        string coin1 = "";
        string coin2 = "";
        string coin3 = "";
        string coin4 = "";
        string coin5 = "";
        string coin6 = "";
        string coin7 = "";
        string coin8 = "";
        string coin9 = "";

        //Custom Coin inputs as full name eg "bitcoin".
        string coin1FN = "";
        string coin2FN = "";
        string coin3FN = "";
        string coin4FN = "";
        string coin5FN = "";
        string coin6FN = "";
        string coin7FN = "";
        string coin8FN = "";
        string coin9FN = "";

        //Variables related to saving to text files.
        string PageNumber;
        string Pages;
        string StartingCurrency;
        string StartingTimeZone;

        //Storing Inputed Coins in an array     ***NEEED TO CHANGE NAME***
        string[] Profile1 = { "", "", "", "", "", "", "", "", "", "" };
        public string[] Profile1Loaded = new string[10];

        //Booleans to Specify the current selected panel.
        bool bOptions = false;
        bool bSummary = true;
        bool bMining = false;
        bool ConfirmAllowed = false;
        bool ProfileLoaded = false;
        bool NewSave;
        bool SYNCED;

        //Profile Number
        double Profile;

        //Variables that are not indexed. Eg Index: 0 is Page 1.
        int pages = 1;
        int PageCalculation;
        int CurrentPage;
        int MaxPages;
        int CurrencyNumber;
        int TimeZoneNumber;

        //Resetting Positions of Panels and Header.
        void Summary01RESET()
        {
            Summary01.Location = new Point(222, 78);
            Summary01.Size = new Size(842, 468);
        }

        void OptionsRESET()
        {
            Options.Location = new Point(222, 78);
            Options.Size = new Size(842, 468);
        }
        void MiningRESET()
        {
            Mining01.Location = new Point(222, 78);
            Mining01.Size = new Size(842, 468);
        }
        void HeaderDefaultRESET()
        {
            btnPageLeft.Location = new Point(6, 47);
            lblCurrentPage.Location = new Point(36, 49);
            btnPageRight.Location = new Point(115, 47);
            lblHeaderCurrency.Location = new Point(169, 49);
            HeaderCurrencyv.Location = new Point(290, 47);
            lblHeaderTime.Location = new Point(436, 49);
            HeaderTimeZonev.Location = new Point(557, 47);
            lblSync.Location = new Point(684, 49);
        }
        
        //Checking and Creating Requiered Files.
        void CreateMustFiles()
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", Convert.ToString(0));
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt", Profile1);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", Convert.ToString(0));
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", Convert.ToString(0));
            }
            else
            {

            }
        }
        

        private void Crypto_Load(object sender, EventArgs e)
        {
            ProfileLoaded = false;      //PLACEHOLDER
            Profile = 1;                //PLACEHOLDER
            CreateMustFiles();
            LoadProfile(Profile);
            TestCoinSummary();
            Summary01RESET();
            HeaderDefaultRESET();
            Pagev.SelectedIndex = Convert.ToInt32(PageNumber);  //Setting Page Index to Saved Page Number on txt file.
            Options.Visible = false;
            Mining01.Visible = false;
            Summary01.Visible = true;
            this.Size = new Size(1064, 546);
            this.CenterToScreen();
            GETINFOSummary();                                 //Getting ALL API Information.
            lblSaveFound.Visible = false;                    //Not Required on first startup.
        }
        
        //Events for moving the actual form.
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Logo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            PageNumber = Convert.ToString(Pagev.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", PageNumber);
        }

        //Universal Hide All Function.
        void HideAll()
        {
            bMining = false;
            bOptions = false;
            bSummary = false;
            Mining01.Visible = false;
            Options.Visible = false;
            Summary01.Visible = false;
            lblConfirmed.Visible = false;
            lblMaxPages.Visible = false;
            lblDefaultSet.Visible = false;
            lblHeaderTime.Visible = false;
            HeaderTimeZonev.Visible = false;
            lblSync.Visible = false;
        }
        void HeaderDefault()
        {
            btnPageLeft.Visible = true;
            btnPageRight.Visible = true;
            lblCurrentPage.Visible = true;
            lblHeaderCurrency.Visible = true;
            HeaderCurrencyv.Visible = true;
            lblHeaderTime.Visible = true;
            HeaderTimeZonev.Visible = true;
            lblSync.Visible = true;
        }

        //All Buttons Events
        private void btnHome_Click(object sender, EventArgs e)
        {
            HideAll();
            bSummary = true;
            Summary01.Visible = true;
            Summary01RESET();
            HeaderDefault();
        }
        private void btnMining_Click(object sender, EventArgs e)
        {
            HideAll();
            bMining = true;
            Mining01.Visible = true;
            MiningRESET();
            btnPageLeft.Visible = false;
            btnPageRight.Visible = false;
            lblCurrentPage.Visible = false;
            lblHeaderCurrency.Visible = false;
            HeaderCurrencyv.Visible = false;
        }
        private void lblSettings_Click(object sender, EventArgs e)
        {
            HideAll();
            bOptions = true;
            Options.Visible = true;
            OptionsRESET();
            HeaderDefault();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            HideAll();
            bSummary = true;
            Summary01.Visible = true;
            Summary01RESET();
            HeaderDefault();
        }
        private void btnPageLeft_Click(object sender, EventArgs e)
        {
            if(Pagev.SelectedIndex == 0)
            {
            }
            else
            {
                btnPageLeft.Enabled = true;
                Pagev.SelectedIndex = Pagev.SelectedIndex - 1;
                UpdatingCurrentPage();
            }
        }
        private void btnPageRight_Click(object sender, EventArgs e)
        {
            MaxPages = Convert.ToInt32(Pages);
            MaxPages = MaxPages - 1;
            if(Pagev.SelectedIndex == MaxPages)
            {

            }
            else
            {
                btnPageRight.Enabled = true;
                Pagev.SelectedIndex = Pagev.SelectedIndex + 1;
                UpdatingCurrentPage();
            }
        }
        
        //Function for Loading the Selected Profile.
        //ProfileNumber is sourced from LoginScreen.
        void LoadProfile(double ProfileNumber)
        {
            if (ProfileNumber == 1)
            {
                try
                {
                    StartingTimeZone = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt");
                    StartingCurrency = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt");
                    PageNumber = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt");
                    Pages = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt");
                    CurrencyNumber = Convert.ToInt32(StartingCurrency);
                    TimeZoneNumber = Convert.ToInt32(StartingTimeZone);
                    PageCalculation = Convert.ToInt32(Pages);
                    for (int i = 0; i < PageCalculation; i++)
                    {
                        Pagev.Items.Add(new Item(Convert.ToString(pages), pages));
                        pages = pages + 1;
                        if (pages > PageCalculation)
                        {
                            pages = pages - 1;
                        }
                        
                    }

                    if (CurrencyNumber == 0)
                    {
                        Currencyv.SelectedIndex = 0;
                    }
                    else if (CurrencyNumber == 1)
                    {
                        Currencyv.SelectedIndex = 1;
                    }

                    if (TimeZoneNumber == 0)
                    {
                        Timezonev.SelectedIndex = 0;
                    }
                    else if (TimeZoneNumber == 1)
                    {
                        Timezonev.SelectedIndex = 1;
                    }

                    //Set all lines from txt file into Array
                    //Set Custonm Coins to data taken from the Array
                    Profile1Loaded = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + PageNumber + ".txt");
                    coin1 = Profile1Loaded[0];
                    coin2 = Profile1Loaded[1];
                    coin3 = Profile1Loaded[2];
                    coin4 = Profile1Loaded[3];
                    coin5 = Profile1Loaded[4];
                    coin6 = Profile1Loaded[5];
                    coin7 = Profile1Loaded[6];
                    coin8 = Profile1Loaded[7];
                    coin9 = Profile1Loaded[8];
                    txtCustom01.Text = coin1;
                    txtCustom02.Text = coin2;
                    txtCustom03.Text = coin3;
                    txtCustom04.Text = coin4;
                    txtCustom05.Text = coin5;
                    txtCustom06.Text = coin6;
                    txtCustom07.Text = coin7;
                    txtCustom08.Text = coin8;
                    txtCustom09.Text = coin9;
                    TestCoinSummary();
                    GETINFOSummary();
                    ProfileLoaded = true;       //Make sure program understands profile loaded successfully. 
                }
                catch (Exception)
                {
                    lblSync.Text = "Saving Error";
                    lblSync.Visible = true;
                }
                
            }
        }
        //Updating Header Page Number
        void UpdatingCurrentPage()
        {
            CurrentPage = Pagev.SelectedIndex + 1;
            lblCurrentPage.Text = "PAGE " + Convert.ToString(CurrentPage);
        }

        //Function for when Index Changes
        void IndexChanged(int SelectedIndex)
        {
            Profile1Loaded = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + Convert.ToString(SelectedIndex) + ".txt");
            coin1 = Profile1Loaded[0];
            coin2 = Profile1Loaded[1];
            coin3 = Profile1Loaded[2];
            coin4 = Profile1Loaded[3];
            coin5 = Profile1Loaded[4];
            coin6 = Profile1Loaded[5];
            coin7 = Profile1Loaded[6];
            coin8 = Profile1Loaded[7];
            coin9 = Profile1Loaded[8];
            txtCustom01.Text = coin1;
            txtCustom02.Text = coin2;
            txtCustom03.Text = coin3;
            txtCustom04.Text = coin4;
            txtCustom05.Text = coin5;
            txtCustom06.Text = coin6;
            txtCustom07.Text = coin7;
            txtCustom08.Text = coin8;
            txtCustom09.Text = coin9;
            TestCoinSummary();
            GETINFOSummary();
            HideConfirmationLabelsSave();
        }
        void SelectedIndexChanged(int Index)
        {
            lblMaxPages.Visible = false;
            if (Pagev.SelectedIndex == Index)
            {
                UpdatingCurrentPage();
                try
                {
                    IndexChanged(Pagev.SelectedIndex);
                }
                catch (Exception)
                {
                    EmptySummary();
                    TestCoinSummary();
                    GETINFOSummary();
                    HideConfirmationLabelsNoSave();
                }
            }
        }
        private void Pagev_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncingTest();
            if (NewSave == true)
            {
                lblNoSave.Visible = false;
                lblNewPage.Text = "New Page Created";
                lblNewPage.Visible = true;
                NewSave = false;
            }
            else
            {
                SelectedIndexChanged(0);
                SelectedIndexChanged(1);
                SelectedIndexChanged(2);
                SelectedIndexChanged(3);
                SelectedIndexChanged(4);
                SelectedIndexChanged(5);
            }
        }
        private void HeaderCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Currencyv.SelectedIndex = HeaderCurrencyv.SelectedIndex;
        }
        private void Currencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncingTest();
            HeaderCurrencyv.SelectedIndex = Currencyv.SelectedIndex;
            lblDefaultSet.Visible = false;
        }
        private void HeaderTimeZonev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Timezonev.SelectedIndex = HeaderTimeZonev.SelectedIndex;
        }
        private void Timezonev_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncingTest();
            HeaderTimeZonev.SelectedIndex = Timezonev.SelectedIndex;
            lblTimeSet.Visible = false;
        }

        //Confirming New Coin Inputs.
        void ConfirmOptionCoins()
        {
            if (ProfileLoaded != true)
            {
                SetConfirmationSummary();
            }
            else
            {


            }
        }
        void SetConfirmationSummary()
        {
            coin1 = txtCustom01.Text;
            coin2 = txtCustom02.Text;
            coin3 = txtCustom03.Text;
            coin4 = txtCustom04.Text;
            coin5 = txtCustom05.Text;
            coin6 = txtCustom06.Text;
            coin7 = txtCustom07.Text;
            coin8 = txtCustom08.Text;
            coin9 = txtCustom09.Text;
        }
        void SaveProfile()
        {
            if (Profile == 1)
            {
                Profile1[0] = coin1;
                Profile1[1] = coin2;
                Profile1[2] = coin3;
                Profile1[3] = coin4;
                Profile1[4] = coin5;
                Profile1[5] = coin6;
                Profile1[6] = coin7;
                Profile1[7] = coin8;
                Profile1[8] = coin9;
                PageNumber = Convert.ToString(Pagev.SelectedIndex);
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page" + PageNumber + ".txt", Profile1);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", PageNumber);
            }
        }
        void GETINFO(string CRYPTO, string customCoin, Label xCv, Label xBTCv, Label xUSDc, Label xUSD24c, Label xUSD7c, Label xUSDp, Label xUSD24p, Label xUSD7p, Label xC, Label xBTC, Label xTimev, GroupBox Number)
        {
            if (Currencyv.SelectedIndex == 0)
            {
                CURRENCY = "USD";
            }
            else if (Currencyv.SelectedIndex == 1)
            {
                CURRENCY = "AUD";
            }

            if (CRYPTO == "" || customCoin == "")
            {
                if(Currencyv.SelectedIndex == 0)
                {
                    xC.Text = "XXX/USD";
                }
                else if (Currencyv.SelectedIndex == 1)
                {
                    xC.Text = "XXX/AUD";
                }
                xBTC.Text = "XXX/BTC";
                xCv.Text = "No Data";
                xBTCv.Text = "No Data";
                xUSDp.Text = "No Data";
                xUSD24p.Text = "No Data";
                xUSD7p.Text = "No Data";
                xUSDc.Text = "";
                xUSD24c.Text = "";
                xUSD7c.Text = "";
                Number.Text = "XXX";
                xTimev.Text = "No Data";

                xCv.ForeColor = Color.White;
                xBTCv.ForeColor = Color.White;
                xUSDp.ForeColor = Color.White;
                xUSD24p.ForeColor = Color.White;
                xUSD7p.ForeColor = Color.White;
            }
            else
            {
                API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO + @"/?convert=" + CURRENCY);

                CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

                xBTC.Text = customCoin + "/BTC";
                Number.Text = customCoin;

                if (Currencyv.SelectedIndex == 0)
                {
                    xC.Text = customCoin + "/USD";
                    foreach (var data in CoinsDetailed)             //Coin Against USD
                    {
                        string price_usd;
                        string percent;
                        double Dpercent;
                        double newprice;
                        price_usd = data.price_usd;
                        price_usd = RemoveExtraText(price_usd);
                        newprice = Convert.ToDouble(price_usd);
                        price_usd = string.Format("{0:#,0.00##}", newprice);
                        price_usd = "$" + price_usd;
                        percent = data.percent_change_1h;
                        percent = RemoveExtraText(percent);
                        Dpercent = Convert.ToDouble(percent);
                        if (Dpercent > 0)
                        {
                            price_usd = "▲ " + price_usd;
                            xCv.ForeColor = Color.Green;
                        }
                        else if (Dpercent < 0)
                        {
                            price_usd = "▼ " + price_usd;
                            xCv.ForeColor = Color.Red;
                        }
                        else if (Dpercent == 0)
                        {
                            xCv.ForeColor = Color.White;
                        }
                        xCv.Text = price_usd;
                        break;
                    }
                }
                else if (Currencyv.SelectedIndex == 1)
                {
                    xC.Text = customCoin + "/AUD";
                    foreach (var data in CoinsDetailed)             //Coin Against AUD
                    {
                        string price_aud;
                        string percent;
                        double Dpercent;
                        double newprice;
                        price_aud = data.price_aud;
                        price_aud = RemoveExtraText(price_aud);
                        newprice = Convert.ToDouble(price_aud);
                        price_aud = string.Format("{0:#,0.00##}", newprice);
                        price_aud = "$" + price_aud;
                        percent = data.percent_change_1h;
                        percent = RemoveExtraText(percent);
                        Dpercent = Convert.ToDouble(percent);
                        if (Dpercent > 0)
                        {
                            price_aud = "▲ " + price_aud;
                            xCv.ForeColor = Color.Green;
                        }
                        else if (Dpercent < 0)
                        {
                            price_aud = "▼ " + price_aud;
                            xCv.ForeColor = Color.Red;
                        }
                        else if (Dpercent == 0)
                        {
                            xCv.ForeColor = Color.White;
                        }
                        xCv.Text = price_aud;
                        break;
                    }
                }
                foreach (var data in CoinsDetailed)         //Calculate Last Updated Time.
                {
                    string Time;
                    string FinalTime;
                    double DTime;
                    Time = data.last_updated;
                    Time = RemoveExtraText(Time);
                    DTime = Convert.ToDouble(Time);
                    DateTime UniversalTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(DTime);
                    DateTime LocalTime = UniversalTime.ToLocalTime();
                    if (Timezonev.SelectedIndex == 0)
                    {
                        FinalTime = UniversalTime.ToString("r");
                        FinalTime = FinalTime.Substring(0, FinalTime.Length - 4);
                        xTimev.Text = FinalTime + " UTC";
                    }
                    else if (Timezonev.SelectedIndex == 1)
                    {
                        FinalTime = LocalTime.ToString("r");
                        FinalTime = FinalTime.Substring(0, FinalTime.Length - 4);
                        xTimev.Text = FinalTime + " LOCAL";
                    }
                    break;
                }
                foreach (var data in CoinsDetailed)         //Coin Against BTC
                {
                    string percent_change_1h;
                    double Dchange;
                    percent_change_1h = data.percent_change_1h;
                    percent_change_1h = RemoveExtraText(percent_change_1h);
                    Dchange = Convert.ToDouble(percent_change_1h);
                    percent_change_1h = percent_change_1h + "%";
                    if (Dchange > 0)
                    {
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.White; }
                        else { xBTCv.ForeColor = Color.Green; }
                    }
                    else if (Dchange < 0)
                    {
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.White; }
                        else { xBTCv.ForeColor = Color.Red; }
                    }
                    else if (Dchange == 0)
                    {
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.White; }
                        else { xBTCv.ForeColor = Color.White; }
                    }
                    string price_btc;
                    double dprice_btc;
                    price_btc = data.price_btc;
                    price_btc = RemoveExtraText(price_btc);
                    dprice_btc = Convert.ToDouble(price_btc);
                    if (data.symbol == "BTC")
                    { price_btc = String.Format("{0:0.0}", dprice_btc); }
                    else
                    { price_btc = String.Format("{0:0.00000000}", dprice_btc); }
                    price_btc = price_btc + " BTC";
                    xBTCv.Text = price_btc;
                    break;
                }
                foreach (var data in CoinsDetailed)         //Calculating all things related to percentages for ANY COIN.
                {
                    string value_changed = null;
                    string convertedPercent = null;
                    string StartingPercent;
                    string price_usd;
                    double Dprice_usd = 0;
                    string price_aud;
                    double Dprice_aud = 0;
                    double DChange = 0;

                    double Dchange = 0;
                    string Data = null;
                    string StartingPercentP;

                    price_usd = data.price_usd;
                    price_aud = data.price_aud;

                    StartingPercent = data.percent_change_1h;
                    CalculatePercentageValue(value_changed, convertedPercent, StartingPercent, price_usd, Dprice_usd, price_aud, Dprice_aud, DChange, xUSDc);
                    StartingPercent = data.percent_change_24h;
                    CalculatePercentageValue(value_changed, convertedPercent, StartingPercent, price_usd, Dprice_usd, price_aud, Dprice_aud, DChange, xUSD24c);
                    StartingPercent = data.percent_change_7d;
                    CalculatePercentageValue(value_changed, convertedPercent, StartingPercent, price_usd, Dprice_usd, price_aud, Dprice_aud, DChange, xUSD7c);

                    StartingPercentP = data.percent_change_1h;
                    CalculatePercentage(Dchange, Data, StartingPercentP, xUSDp);
                    StartingPercentP = data.percent_change_24h;
                    CalculatePercentage(Dchange, Data, StartingPercentP, xUSD24p);
                    StartingPercentP = data.percent_change_7d;
                    CalculatePercentage(Dchange, Data, StartingPercentP, xUSD7p);
                    break;
                }
            }
            
        }
        void CalculatePercentageValue(string value_changed, string convertedPercent, string StartingPercent, string price_usd, double Dprice_usd, string price_aud, double Dprice_aud, double DChange, Label ValueText)
        {
            if (StartingPercent == null)
            {
                ValueText.Text = "";
            }
            else
            {
                convertedPercent = RemoveExtraText(StartingPercent);
                if (CURRENCY == "USD")
                {
                    
                    price_usd = RemoveExtraText(price_usd);
                    double totalPercent;
                    totalPercent = Convert.ToDouble(convertedPercent);
                    totalPercent = totalPercent / 100;
                    if (totalPercent >= 0)
                    {
                        totalPercent = totalPercent + 1;
                    }
                    else if (totalPercent < 0)
                    {
                        totalPercent = totalPercent - 1;
                    }
                    Dprice_usd = Convert.ToDouble(price_usd);
                    DChange = Dprice_usd / totalPercent;
                    value_changed = Convert.ToString(DChange);
                    if (DChange < 0)
                    {
                        DChange = DChange * -1;
                        DChange = Dprice_usd - DChange;
                        value_changed = Convert.ToString(DChange);
                        if (DChange == 0)
                        {
                            ValueText.ForeColor = Color.White;
                        }
                        else
                        {
                            ValueText.ForeColor = Color.Red;
                            value_changed = value_changed.Substring(0, 8);
                        }
                    }
                    else if (DChange > 0)
                    {
                        DChange = Dprice_usd - DChange;
                        value_changed = Convert.ToString(DChange);
                        if (DChange == 0)
                        {
                            ValueText.ForeColor = Color.White;
                        }
                        else
                        {
                            ValueText.ForeColor = Color.Green;
                            value_changed = value_changed.Substring(0, 8);
                        }

                    }
                    value_changed = "$" + value_changed;
                    ValueText.Text = value_changed;
                }
                else if (CURRENCY == "AUD")
                {
                    
                    price_aud = RemoveExtraText(price_aud);
                    double totalPercent;
                    totalPercent = Convert.ToDouble(convertedPercent);
                    totalPercent = totalPercent / 100;
                    if (totalPercent >= 0)
                    {
                        totalPercent = totalPercent + 1;
                    }
                    else if (totalPercent < 0)
                    {
                        totalPercent = totalPercent - 1;
                    }
                    Dprice_aud = Convert.ToDouble(price_aud);
                    DChange = Dprice_aud / totalPercent;
                    value_changed = Convert.ToString(DChange);
                    if (DChange < 0)
                    {
                        DChange = DChange * -1;
                        DChange = Dprice_aud - DChange;
                        value_changed = Convert.ToString(DChange);
                        if (DChange == 0)
                        {
                            ValueText.ForeColor = Color.White;
                        }
                        else
                        {
                            ValueText.ForeColor = Color.Red;
                            value_changed = value_changed.Substring(0, 8);
                        }
                    }
                    else if (DChange > 0)
                    {
                        DChange = Dprice_aud - DChange;
                        value_changed = Convert.ToString(DChange);
                        if (DChange == 0)
                        {
                            ValueText.ForeColor = Color.White;
                        }
                        else
                        {
                            ValueText.ForeColor = Color.Green;
                            value_changed = value_changed.Substring(0, 8);
                        }

                    }
                    value_changed = "$" + value_changed;
                    ValueText.Text = value_changed;
                }
            }
        }
        void CalculatePercentage(double Dchange, string Data, string StartingPercentP, Label PercentText)
        {
            if (StartingPercentP == null)
            {
                PercentText.Text = "No Data";
                PercentText.ForeColor = Color.White;
            }
            else
            {
                Data = RemoveExtraText(StartingPercentP);
                Dchange = Convert.ToDouble(Data);
                Data = Data + "%";
                if (Dchange > 0)
                {
                    PercentText.ForeColor = Color.Green;
                }
                else if (Dchange < 0)
                {
                    PercentText.ForeColor = Color.Red;
                }
                else if (Dchange == 0)
                {
                    PercentText.ForeColor = Color.White;
                }
                PercentText.Text = Data;
            }
        }
        private string RemoveExtraText(string value)
        {
            var allowedChars = "01234567890.,-";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
            
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public void API(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                lblSync.Text = "API Error";
                lblSync.Visible = true;
            }
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            GETINFOSummary();
        }
        void GETINFOSummary()
        {
            try
            {
                GETINFO(coin1FN, coin1, lblCustomCv01, lblCustomBTCv01, lblCustom1Hc01, lblCustom24Hc01, lblCustom7Dc01, lblCustom1Hp01, lblCustom24Hp01, lblCustom7Dp01, lblCustomC01, lblCustomBTC01, lblCustomUpdatedv01, customGroup01);
                GETINFO(coin2FN, coin2, lblCustomCv02, lblCustomBTCv02, lblCustom1Hc02, lblCustom24Hc02, lblCustom7Dc02, lblCustom1Hp02, lblCustom24Hp02, lblCustom7Dp02, lblCustomC02, lblCustomBTC02, lblCustomUpdatedv02, customGroup02);
                GETINFO(coin3FN, coin3, lblCustomCv03, lblCustomBTCv03, lblCustom1Hc03, lblCustom24Hc03, lblCustom7Dc03, lblCustom1Hp03, lblCustom24Hp03, lblCustom7Dp03, lblCustomC03, lblCustomBTC03, lblCustomUpdatedv03, customGroup03);
                GETINFO(coin4FN, coin4, lblCustomCv04, lblCustomBTCv04, lblCustom1Hc04, lblCustom24Hc04, lblCustom7Dc04, lblCustom1Hp04, lblCustom24Hp04, lblCustom7Dp04, lblCustomC04, lblCustomBTC04, lblCustomUpdatedv04, customGroup04);
                GETINFO(coin5FN, coin5, lblCustomCv05, lblCustomBTCv05, lblCustom1Hc05, lblCustom24Hc05, lblCustom7Dc05, lblCustom1Hp05, lblCustom24Hp05, lblCustom7Dp05, lblCustomC05, lblCustomBTC05, lblCustomUpdatedv05, customGroup05);
                GETINFO(coin6FN, coin6, lblCustomCv06, lblCustomBTCv06, lblCustom1Hc06, lblCustom24Hc06, lblCustom7Dc06, lblCustom1Hp06, lblCustom24Hp06, lblCustom7Dp06, lblCustomC06, lblCustomBTC06, lblCustomUpdatedv06, customGroup06);
                GETINFO(coin7FN, coin7, lblCustomCv07, lblCustomBTCv07, lblCustom1Hc07, lblCustom24Hc07, lblCustom7Dc07, lblCustom1Hp07, lblCustom24Hp07, lblCustom7Dp07, lblCustomC07, lblCustomBTC07, lblCustomUpdatedv07, customGroup07);
                GETINFO(coin8FN, coin8, lblCustomCv08, lblCustomBTCv08, lblCustom1Hc08, lblCustom24Hc08, lblCustom7Dc08, lblCustom1Hp08, lblCustom24Hp08, lblCustom7Dp08, lblCustomC08, lblCustomBTC08, lblCustomUpdatedv08, customGroup08);
                GETINFO(coin9FN, coin9, lblCustomCv09, lblCustomBTCv09, lblCustom1Hc09, lblCustom24Hc09, lblCustom7Dc09, lblCustom1Hp09, lblCustom24Hp09, lblCustom7Dp09, lblCustomC09, lblCustomBTC09, lblCustomUpdatedv09, customGroup09);
                SYNCED = true;
            }
            catch (Exception)
            {
                lblSync.Text = "SYNC NOW";
                lblSync.Visible = true;
            }

        }

        //SETTINGS
        //SETTINGS BUTTONS
        private void btnEditSummary_Click(object sender, EventArgs e)
        {
            EditSummary();
            btnEditSummary.Visible = false;
            btnClearSummary.Visible = true;
        }
        private void btnConfirmSummary_Click(object sender, EventArgs e)
        {
            ConfirmSummary();
            btnEditSummary.Visible = true;
            btnClearSummary.Visible = false;
        }
        private void btnClearSummary_Click(object sender, EventArgs e)
        {
            txtCustom01.Text = "";
            txtCustom02.Text = "";
            txtCustom03.Text = "";
            txtCustom04.Text = "";
            txtCustom05.Text = "";
            txtCustom06.Text = "";
            txtCustom07.Text = "";
            txtCustom08.Text = "";
            txtCustom09.Text = "";
        }
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
            lblSaved.Visible = true;
            int CurrentPage = Pagev.SelectedIndex + 1;
            int CurrentIndex = Pagev.SelectedIndex;
            lblSaved.Text = "Saved to Page " + Convert.ToString(CurrentPage);
        }
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            HideConfirmationLabelsNewSave();
            NewSave = true;
            pages = pages + 1;
            if (pages == 7)
            {
                pages = pages - 1;
                lblMaxPages.Visible = true;
                lblNoSave.Visible = false;
                lblNewPage.Visible = false;
                NewSave = false;
            }
            else
            {
                Pagev.Items.Add(new Item(Convert.ToString(pages), pages));
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                Pagev.SelectedIndex = pages - 1;
                CurrentPage = Pagev.SelectedIndex + 1;
                lblCurrentPage.Text = "PAGE " + Convert.ToString(CurrentPage);
                EmptySummary();
            }
        }
        private void btnTimeDefault_Click(object sender, EventArgs e)
        {
            StartingTimeZone = Convert.ToString(Timezonev.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", StartingTimeZone);
            lblTimeSet.Visible = true;
        }
        private void btnCurrencyDefault_Click(object sender, EventArgs e)
        {
            StartingCurrency = Convert.ToString(Currencyv.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", StartingCurrency);
            lblDefaultSet.Visible = true;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.None;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SyncingTest();
        }
        void SyncingTest()
        {
            SYNCED = false;
            lblSync.Text = "SYNCING...";
            lblSync.Visible = true;
            gifRefreshing.Visible = true;
            GETINFOSummary();
            timerRefreshing.Enabled = true;
        }
        public void TaskAwait()
        {
            new System.Threading.ManualResetEvent(false).WaitOne(50);
        }
        private void timerRefreshing_Tick(object sender, EventArgs e)
        {
            if (SYNCED == false)
            {

            }
            else if (SYNCED == true)
            {
                timerRefreshing.Enabled = false;
                lblSync.Text = "SYNCED";
                gifRefreshing.Visible = false;
            }

        }
        private void event_SummaryHover(object sender, EventArgs e)
        {

        }

        private void timerUpdating_Tick(object sender, EventArgs e)
        {

        }
        void TestCoinSummary()
        {
            ConfirmOptionCoins();
            TestOptionCoins(ref coin1, ref coin1FN);
            TestOptionCoins(ref coin2, ref coin2FN);
            TestOptionCoins(ref coin3, ref coin3FN);
            TestOptionCoins(ref coin4, ref coin4FN);
            TestOptionCoins(ref coin5, ref coin5FN);
            TestOptionCoins(ref coin6, ref coin6FN);
            TestOptionCoins(ref coin7, ref coin7FN);
            TestOptionCoins(ref coin8, ref coin8FN);
            TestOptionCoins(ref coin9, ref coin9FN);
        }
        public void TestOptionCoins(ref string RealCoin, ref string RealCoinFN)
        {
            try
            {
                API(@"https://api.coinmarketcap.com/v1/ticker/?start=0&limit=0");

                double counting = 0;

                Coins = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);
                if (RealCoin.ToUpper() == "BTC" || RealCoin.ToUpper() == "BITCOIN")
                {
                    RealCoin = "BTC";
                    RealCoinFN = "bitcoin";
                }
                else if (RealCoin == "")
                {
                    RealCoin = "";
                    RealCoinFN = "";
                }
                else
                {
                    foreach (var coin in Coins)
                    {
                        counting = counting + 1;
                        if (coin.name.ToUpper() == RealCoin.ToUpper())
                        {
                            RealCoin = coin.symbol;
                            RealCoinFN = coin.id.ToLower();
                            break;
                        }
                        else if (coin.symbol == RealCoin.ToUpper())
                        {
                            RealCoin = coin.symbol;
                            RealCoinFN = coin.id;
                            break;
                        }
                        else if (counting == 1545)
                        {
                            RealCoin = "";
                            RealCoinFN = "";
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblSync.Text = "Coin Error";
                lblSync.Visible = true;
            }

        }
        void EditSummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = false;
            Custom.BackColor = Color.DarkGray;
        }
        void EditSummary()
        {
            EditSummaryIndividual(txtCustom01);
            EditSummaryIndividual(txtCustom02);
            EditSummaryIndividual(txtCustom03);
            EditSummaryIndividual(txtCustom04);
            EditSummaryIndividual(txtCustom05);
            EditSummaryIndividual(txtCustom06);
            EditSummaryIndividual(txtCustom07);
            EditSummaryIndividual(txtCustom08);
            EditSummaryIndividual(txtCustom09);
            ConfirmAllowed = true;
            ProfileLoaded = false;
        }
        void EmptySummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = true;
            Custom.BackColor = Color.Gray;
            Custom.Text = "";
        }
        void EmptySummary()
        {
            EmptySummaryIndividual(txtCustom01);
            EmptySummaryIndividual(txtCustom02);
            EmptySummaryIndividual(txtCustom03);
            EmptySummaryIndividual(txtCustom04);
            EmptySummaryIndividual(txtCustom05);
            EmptySummaryIndividual(txtCustom06);
            EmptySummaryIndividual(txtCustom07);
            EmptySummaryIndividual(txtCustom08);
            EmptySummaryIndividual(txtCustom09);
            TestCoinSummary();
            GETINFOSummary();
        }
        void ConfirmSummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = true;
            Custom.BackColor = Color.Gray;
        }
        void ConfirmSummary()
        {
            while (ConfirmAllowed == true)
            {
                ConfirmSummaryIndividual(txtCustom01);
                ConfirmSummaryIndividual(txtCustom02);
                ConfirmSummaryIndividual(txtCustom03);
                ConfirmSummaryIndividual(txtCustom04);
                ConfirmSummaryIndividual(txtCustom05);
                ConfirmSummaryIndividual(txtCustom06);
                ConfirmSummaryIndividual(txtCustom07);
                ConfirmSummaryIndividual(txtCustom08);
                ConfirmSummaryIndividual(txtCustom09);
                lblConfirmed.Visible = true;
                TestCoinSummary();
                GETINFOSummary();
                ConfirmAllowed = false;
            }
        }
        void HideConfirmationLabelsSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = true;
        }
        void HideConfirmationLabelsNoSave()
        {
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblSaveFound.Visible = false;
            lblMaxPages.Visible = false;
            lblNoSave.Visible = true;
        }
        void HideConfirmationLabelsNewSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = false;
            lblNewPage.Visible = true;
        }

        //MINING

    }
}
