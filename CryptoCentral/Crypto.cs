using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
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
        List<CryptoCentral.NHAlgos> NHAlgo;

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
        bool SYNCING;
        bool ChangingPage = false;

        //Profile Number
        double Profile;

        //Variables that are not indexed. Eg Index: 0 is Page 1.
        int pages = 1;
        int PageCalculation;
        int CurrentPage;
        int MaxPages;
        int CurrencyNumber;
        int TimeZoneNumber;





        //MINING
        double UniversalBTCPrice;


        List<string> NHWallets;
        string NewNHWallet;
        string[] NHWalletsA;
        string CurrentNHWallet;
        int WalletIndexChecker;

        BindingSource BindWallet = new BindingSource();

        string lineWorker;
        string lineNHAlgo;
        string lineHashRate;


        string NHRelWorkers;
        string[] NHRelWorkersA;
        string[] SepDATA;
        string WorkerID;
        string DATA;

        string SCurrentAlgo;
        string KeyCurrentAlgo;
        string Verified;
        
        double CurrentHashRate;
        double CurrentRejectRate;
        string SHashEnd;
        string SCurrentHashRate;
        string SCurrentRejectRate;
        double DEfficiency;
        string SEfficiency;
        double SUpTimeBeforeCalc;
        string STimeDays = null;
        string STimeHours = null;
        string STimeMins = null;
        string STimeSeconds = null;

        string WorkerIDCheck;


        string NHProfitability;
        string NHRelProfit;
        string[] NHRelProfitA;
        string NHActualAlgoS;
        int NHActualAlgoI;

        string NHCalcProfitRate;
        double NHCalcProfitBTCD;
        string NHCalcProfitBTC;
        string NHCalcProfitBTCM;
        string NHCalcProfitBTCY;

        int NoWorkers;
        int TimeIndexRemove;

        Dictionary<int, string> RealProfit = new Dictionary<int, string>();

        List<string> SepProfit = new List<string>();
        List<string> SepWorkers = new List<string>();
        List<string> RealWorkers = new List<string>();
        List<string> StartingMiningSettings = new List<string>();

        bool TimeCalc = false;



        int intSyncTimer;
        string stringSyncTimer;







        //Resetting Positions of Panels and Header.
        void Summary01RESET()
        {
            Summary01.Location = new Point(222, 71);
            Summary01.Size = new Size(842, 468);
        }

        void OptionsRESET()
        {
            Options.Location = new Point(222, 71);
            Options.Size = new Size(842, 468);
        }
        void MiningRESET()
        {
            Mining01.Location = new Point(222, 71);
            Mining01.Size = new Size(842, 468);
        }
        void HeaderDefaultRESET()
        {
            btnPageLeft.Location = new Point(6, 7);
            lblCurrentPage.Location = new Point(36, 9);
            btnPageRight.Location = new Point(115, 7);
            lblSync.Location = new Point(638, 9);
            gifRefreshing.Location = new Point(758, 7);
            btnRefresh.Location = new Point(758, 7);
        }
        void HeaderMiningRESET()
        {
            lblHeaderPool.Location = new Point(13, 40);
            HeaderPoolv.Location = new Point(83, 38);
            lblHeaderWorker.Location = new Point(234, 40);
            HeaderWorkerv.Location = new Point(334, 38);
            lblHeaderMiningCurrency.Location = new Point(530, 40);
            HeaderMiningCurrencyv.Location = new Point(651, 38);
        }
        //Checking and Creating Requiered Files.
        void CreateMustFiles()
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining");
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", Convert.ToString(0));
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt", Profile1);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", Convert.ToString(0));
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", Convert.ToString(0));
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", "");
            }
        }
        

        private void Crypto_Load(object sender, EventArgs e)
        {
            ProfileLoaded = false;      //PLACEHOLDER
            Profile = 0;                //PLACEHOLDER
            CreateMustFiles();
            LoadProfile(Profile);
            TestCoinSummary();
            Summary01RESET();
            HeaderDefaultRESET();
            HeaderMiningRESET();
            HeaderDefault();
            Pagev.SelectedIndex = Convert.ToInt32(PageNumber);  //Setting Page Index to Saved Page Number on txt file.
            intSyncTimer = 31;
            lblSyncTimer.Location = new Point(789, 7);
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining");        //PLACEHOLDER
            GETWallets();                                           //MINING | Gets All Wallet Info
            GETPools();                                             //MINING | Gets All Available Pools
            SetDefault();

            Options.Visible = false;
            Mining01.Visible = false;
            Summary01.Visible = true;
            Footer.Location = new Point(222, 539);
            this.Size = new Size(1064, 577);
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
        }
        void HeaderDefault()
        {
            btnPageLeft.Visible = true;
            btnPageRight.Visible = true;
            lblCurrentPage.Visible = true;
            
        }
        void HeaderMining()
        {
            btnPageLeft.Visible = false;
            btnPageRight.Visible = false;
            lblCurrentPage.Visible = false;
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
            HeaderMining();
            
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
        
        //Function for Loading the Selected Profile.
        //ProfileNumber is sourced from LoginScreen.
        void LoadProfile(double ProfileNumber)
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
            HideConfirmationLabelsSave();
        }
        void SelectedIndexChanged(int Index)
        {
            lblMaxPages.Visible = false;
            if (Pagev.SelectedIndex == Index)
            {
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
                SelectedIndexChanged(Pagev.SelectedIndex);
                UpdatingCurrentPage();
            }
            btnPageLeft.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-still-24px.png");
            btnPageRight.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-still-24px.png");
        }
        private void Currencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncingTest();
            lblDefaultSet.Visible = false;
        }
        private void Timezonev_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncingTest();
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
                Number.Text = "      " + "XXX";
                xTimev.Text = "No Data";

                xCv.ForeColor = Color.Black;
                xBTCv.ForeColor = Color.Black;
                xUSDp.ForeColor = Color.Black;
                xUSD24p.ForeColor = Color.Black;
                xUSD7p.ForeColor = Color.Black;
            }
            else
            {
                API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO + @"/?convert=" + CURRENCY);

                CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

                xBTC.Text = customCoin + "/BTC";
                Number.Text = "";
                Number.Text = "      " + customCoin;

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
                        if (CRYPTO == "bitcoin")
                        {
                            UniversalBTCPrice = newprice;
                        }
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
                            xCv.ForeColor = Color.Black;
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
                            xCv.ForeColor = Color.Black;
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
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.Black; }
                        else { xBTCv.ForeColor = Color.Green; }
                    }
                    else if (Dchange < 0)
                    {
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.Black; }
                        else { xBTCv.ForeColor = Color.Red; }
                    }
                    else if (Dchange == 0)
                    {
                        if (data.symbol == "BTC") { xBTCv.ForeColor = Color.Black; }
                        else { xBTCv.ForeColor = Color.Black; }
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
                            ValueText.ForeColor = Color.Black;
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
                            ValueText.ForeColor = Color.Black;
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
                            ValueText.ForeColor = Color.Black;
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
                            ValueText.ForeColor = Color.Black;
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
                PercentText.ForeColor = Color.Black;
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
                    PercentText.ForeColor = Color.Black;
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

        //AUTO FETCH DATA | 30seconds
        private void timerSyncTimer_Tick(object sender, EventArgs e)
        {
            if (intSyncTimer == 0)
            {
                SyncingTest();
                intSyncTimer = 31;
            }
            else if (SYNCED == true)
            {
                intSyncTimer = intSyncTimer - 1;
                if (intSyncTimer > 30)
                {

                }
                else
                {
                    stringSyncTimer = Convert.ToString(intSyncTimer);
                    lblSyncTimer.Text = "(" + stringSyncTimer + ")";
                }
            }
            else
            {
                intSyncTimer = intSyncTimer - 1;
                stringSyncTimer = Convert.ToString(intSyncTimer);
                lblSyncTimer.Text = "(" + stringSyncTimer + ")";
            }
        }

        //UPDATES ALL INFORMATION AFFECTING EVERY LABEL AND GROUPBOX | VERY IMPORTANT
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
        //ALLOWS CUSTOM COIN ENTRIES TO BE EDITTED
        private void btnEditSummary_Click(object sender, EventArgs e)
        {
            EditSummary();
            btnEditSummary.Visible = false;
            btnClearSummary.Visible = true;
        }
        //CONFIRMS INPUTTED COINS AND SWITCHES TEXTBOX TO READ ONLY
        private void btnConfirmSummary_Click(object sender, EventArgs e)
        {
            ConfirmSummary();
            btnEditSummary.Visible = true;
            btnClearSummary.Visible = false;
        }
        //CLEARS ALL ENTRIES
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

        //SAVES CURRENT PAGE SELECTION TO MEMORY
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
            lblSaved.Visible = true;
            int CurrentPage = Pagev.SelectedIndex + 1;
            int CurrentIndex = Pagev.SelectedIndex;
            lblSaved.Text = "Saved to Page " + Convert.ToString(CurrentPage);
        }

        //CREATES A NEW PAGE
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            HideConfirmationLabelsNewSave();
            NewSave = true;
            pages = pages + 1;
            if (pages == 7)     //MAKES SURE THE MAX PAGE IS 7 | //FOR NOW
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
                EmptySummary();     //EMPTYS THE SUMMARY COINS FOR NEW PAGE INPUTS
            }
        }

        //SET DEFAULT TIMEZONE SELECTION
        private void btnTimeDefault_Click(object sender, EventArgs e)
        {
            StartingTimeZone = Convert.ToString(Timezonev.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\TimeZone.txt", StartingTimeZone);
            lblTimeSet.Visible = true;
        }

        //SET DEFAULT CURRENCY SELECTION
        private void btnCurrencyDefault_Click(object sender, EventArgs e)
        {
            StartingCurrency = Convert.ToString(Currencyv.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", StartingCurrency);
            lblDefaultSet.Visible = true;
        }

        //MINIMISE THE FORM
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.None;
        }

        //SYNCING
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SyncingTest();
        }

        //INITIATE THE SYNC
        void SyncingTest()
        {
            ShowcustomRefresh();
            timerUpdating.Enabled = true;
            SYNCED = false;
        }

        //CONSTANTLY CHECKS IF LBLS ARE CORRECT | 50ms
        private void timerRefreshing_Tick(object sender, EventArgs e)
        {
            if (SYNCED == false)
            {
                lblSync.Text = "SYNCING...";
                gifRefreshing.Visible = true;
            }
            else if (SYNCED == true)
            {
                HidecustomRefresh();
                lblSync.Text = "SYNCED";
                gifRefreshing.Visible = false;
            }

        }

        //UPDATES THE DATA ON REFRESH | 2000ms
        private void timerUpdating_Tick(object sender, EventArgs e)
        {
            if (SYNCED == false)
            {
                ShowcustomRefresh();
                lblSync.Text = "SYNCING...";        //REQUIRED FOR SYNCING LABELS TO WORK FOR PAGE SWITHCING
                gifRefreshing.Visible = true;       //REQUIRED FOR SYNCING LABELS TO WORK FOR PAGE SWITCHING
                if (bSummary == true)
                {
                    GETINFOSummary();
                }
                else if (bMining == true)
                {
                    if (HeaderPoolv.Text == "NICEHASH")
                    {
                        GETNHWorkerRefresh();
                    }
                    GETWorkerInfo();
                }
                else if (bOptions == true)
                {
                    GETINFOSummary();
                }
            }
            else if (SYNCED == true)
            {
                HidecustomRefresh();
                timerUpdating.Enabled = false;
            }
        }

        private void event_SummaryHover(object sender, EventArgs e)
        {

        }

        //TESTING NEW COIN INPUTS 
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
        //LOGIC BEHIND ALLOCATING NEW STRING FOR INPUTTED CUSTOM COIN
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
                        else if (counting == 1545)      //MAX COINS IN API READER
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

        //SETTINGS BUTTON FUNCTIONS
        //CUT DOWN ON LINES OF CODE
        void EditSummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = false;
            Custom.BackColor = Color.White;
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
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

        //CUT DOWN ON LINES OF CODE
        void EmptySummaryIndividual(TextBox Custom)
        {
            Custom.ReadOnly = false;
            Custom.BackColor = Color.White;
            Custom.Text = "";
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
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

        //CUT DOWN ON LINES OF CODE
        void ConfirmSummaryIndividual(TextBox Custom)
        {
            Custom.BackColor = Color.WhiteSmoke;
            Custom.ReadOnly = true;
        }
        //REPEAT ABOVE FUNCTION FOR ALL CUSTOM COINS
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

        //EASE OF ACCESS
        //HIDE ALL LBL EXCEPT SAVE FOUND
        void HideConfirmationLabelsSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = true;
        }
        //HIDE ALL LBL EXCEPT NO SAVE FOUND
        void HideConfirmationLabelsNoSave()
        {
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNewPage.Visible = false;
            lblSaveFound.Visible = false;
            lblMaxPages.Visible = false;
            lblNoSave.Visible = true;
        }
        //HIDE ALL LBL EXCEPT NEW PAGE CREATED
        void HideConfirmationLabelsNewSave()
        {
            lblMaxPages.Visible = false;
            lblConfirmed.Visible = false;
            lblSaved.Visible = false;
            lblNoSave.Visible = false;
            lblSaveFound.Visible = false;
            lblNewPage.Visible = true;
        }
        void HidecustomRefresh()
        {
            HideorShowRefresh(customRefresh01, false);
            HideorShowRefresh(customRefresh02, false);
            HideorShowRefresh(customRefresh03, false);
            HideorShowRefresh(customRefresh04, false);
            HideorShowRefresh(customRefresh05, false);
            HideorShowRefresh(customRefresh06, false);
            HideorShowRefresh(customRefresh07, false);
            HideorShowRefresh(customRefresh08, false);
            HideorShowRefresh(customRefresh09, false);
        }
        void ShowcustomRefresh()
        {
            HideorShowRefresh(customRefresh01, true);
            HideorShowRefresh(customRefresh02, true);
            HideorShowRefresh(customRefresh03, true);
            HideorShowRefresh(customRefresh04, true);
            HideorShowRefresh(customRefresh05, true);
            HideorShowRefresh(customRefresh06, true);
            HideorShowRefresh(customRefresh07, true);
            HideorShowRefresh(customRefresh08, true);
            HideorShowRefresh(customRefresh09, true);
        }
        void HideorShowRefresh(PictureBox Refresh, bool Status)
        {
            if (Status == true)
            {
                Refresh.Image = Image.FromFile(@"Resources\RefreshAnimation-24px.gif");
            }
            else if (Status == false)
            {
                Refresh.Image = Image.FromFile(@"Resources\reload.png");
            }
        }
        private void btnPageHoverEnter(object sender, EventArgs e)
        {

        }

        private void btnPageHoverLeave(object sender, EventArgs e)
        {
            PictureBox btnPageControl = (PictureBox)sender;

            if (btnPageControl.Name == "btnPageLeft")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-still-24px.png");
            }
            else if (btnPageControl.Name == "btnPageRight")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-still-24px.png");
            }
        }

        private void btnPageControlClick(object sender, EventArgs e)
        {
            PictureBox btnPageControl = (PictureBox)sender;

            if (btnPageControl.Name == "btnPageLeft")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\left-arrow-clicked-24px.png");
                if (Pagev.SelectedIndex != 0)
                {
                    btnPageLeft.Enabled = true;
                    Pagev.SelectedIndex = Pagev.SelectedIndex - 1;
                    UpdatingCurrentPage();
                }
            }
            else if (btnPageControl.Name == "btnPageRight")
            {
                btnPageControl.Image = Image.FromFile(@"C:\Users\" + Environment.UserName + @"\Documents\GitHub\CryptoCentral\Images\right-arrow-clicked-24px.png");
                MaxPages = Convert.ToInt32(Pages);
                MaxPages = MaxPages - 1;
                if (Pagev.SelectedIndex != MaxPages)
                {
                    btnPageRight.Enabled = true;
                    Pagev.SelectedIndex = Pagev.SelectedIndex + 1;
                    UpdatingCurrentPage();
                }
            }
        }




        //MINING
        void SetDefault()
        {
            StartingMiningSettings.Clear();
            StartingMiningSettings = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt").ToList();
            HeaderPoolv.Text = StartingMiningSettings[0];
            HeaderWorkerv.Text = StartingMiningSettings[1];
            HeaderMiningCurrencyv.SelectedIndex = Convert.ToInt32(StartingMiningSettings[2]);
        }
        void GETWallets()
        {
            NHWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt").ToList();
            NHWalletsA = NHWallets.ToArray();
            BindWallet.DataSource = NHWalletsA;
            OptionsNHWalletsv.DataSource = BindWallet.DataSource;
            CurrentNHWallet = OptionsNHWalletsv.Text;

        }
        void GETPools()
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt"))
            {
                if (HeaderPoolv.Items.Contains("NICEHASH")) { }
                else
                {
                    HeaderPoolv.Items.Add("NICEHASH");
                }
            }
        }
        void GETNHWorkerRefresh()
        {
            string url = @"https://api.nicehash.com/api?method=stats.provider.workers&addr=" + CurrentNHWallet;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                lineWorker = reader.ReadToEnd();
                NHRelWorkers = getBetween(lineWorker, ":[", "\"algo");
                NHRelWorkersA = Regex.Split(NHRelWorkers, "],");
                SepWorkers = NHRelWorkersA.OfType<string>().ToList();
                for (int x = 0; x < SepWorkers.Count; x++)
                {
                    if (SepWorkers[x] != "")
                    {
                        WorkerID = SepWorkers[x];
                        WorkerID = RemoveforMiningKeepingCurly(WorkerID);
                        int RemoveA = WorkerID.LastIndexOf("{");
                        if (RemoveA > 0)
                        {
                            WorkerID = WorkerID.Substring(0, RemoveA);
                        }
                        else if (RemoveA == 0)
                        {
                            WorkerID = "EMPTY";
                        }
                        if (bMining == false)
                        {
                            HeaderWorkerv.Items.Add(WorkerID);
                            RealWorkers.Add(WorkerID);
                        }
                    }
                    else if (SepWorkers[x] == "")
                    {
                        break;
                    }

                }
            }
        }
        void GETWorkers()
        {
            HeaderWorkerv.Items.Clear();
            
            if (HeaderPoolv.Text == "NICEHASH")
            {
                GETNHWorkerRefresh();
            }
        }
        void WorkerTimeCalculation()
        {
            if (SUpTimeBeforeCalc == 0)
            {
                lblWorkerUpTimev.Text = "Just Started";
            }
            else
            {
                while (TimeCalc == false)
                {
                    if ((SUpTimeBeforeCalc / 86400) < 1 && STimeDays == null)
                    {
                        STimeDays = "";
                    }
                    else if ((SUpTimeBeforeCalc / 86400) >= 1 && STimeDays == null)
                    {
                        STimeDays = Convert.ToString(SUpTimeBeforeCalc / 86400);
                        STimeDays = RemoveAfterLetter(STimeDays, ".");
                        STimeDays = " " + STimeDays + "D";
                    }
                    else if ((SUpTimeBeforeCalc / 3600) < 1 && STimeHours == null)
                    {
                        STimeHours = "";
                    }
                    else if ((SUpTimeBeforeCalc / 3600) >= 1 && STimeHours == null)
                    {
                        if (SUpTimeBeforeCalc / 3600 > 24)
                        {
                            STimeHours = Convert.ToString((SUpTimeBeforeCalc / 3600) - 24);
                            STimeHours = RemoveAfterLetter(STimeHours, ".");
                            STimeHours = " " + STimeHours + "H";
                        }
                        else
                        {
                            STimeHours = Convert.ToString(SUpTimeBeforeCalc / 3600);
                            STimeHours = RemoveAfterLetter(STimeHours, ".");
                            STimeHours = " " + STimeHours + "H";
                        }
                    }
                    else if (((SUpTimeBeforeCalc / 60) % 60) < 1 && STimeMins == null)
                    {
                        STimeMins = "";
                    }
                    else if (((SUpTimeBeforeCalc / 60) % 60) >= 1 && STimeMins == null)
                    {
                        STimeMins = Convert.ToString((SUpTimeBeforeCalc / 60) % 60);
                        STimeMins = RemoveAfterLetter(STimeMins, ".");
                        STimeMins = " " + STimeMins + "M";
                    }
                    else if ((SUpTimeBeforeCalc % 60) < 1 && STimeSeconds == null)
                    {
                        STimeSeconds = "";
                    }
                    else if ((SUpTimeBeforeCalc % 60) >= 1 && STimeSeconds == null)
                    {
                        STimeSeconds = Convert.ToString(SUpTimeBeforeCalc % 60);
                        STimeSeconds = RemoveAfterLetter(STimeSeconds, ".");
                        STimeSeconds = " " + STimeSeconds + "S";
                    }
                    else
                    {
                        TimeCalc = true;
                    }
                }
                lblWorkerUpTimev.Text = STimeDays + STimeHours + STimeMins + STimeSeconds;
            }
        }
        public string RemoveAfterLetter(string Remove, string Letter)
        {
            TimeIndexRemove = Remove.LastIndexOf(Letter);
            if (TimeIndexRemove > 0) { Remove = Remove.Substring(0, TimeIndexRemove); }
            return Remove;
        }
        void GETWorkerInfoNH()
        {
            lblWorkerIDv.Text = WorkerID;

            SUpTimeBeforeCalc = SUpTimeBeforeCalc * 60;
            WorkerTimeCalculation();

            if (Verified == "1")
            {
                lblWorkerVerifiedv.Text = "YES";
                lblWorkerVerifiedv.ForeColor = Color.LightGreen;
            }
            else if (Verified == "0")
            {
                lblWorkerVerifiedv.Text = "NO";
                lblWorkerVerifiedv.ForeColor = Color.Red;
            }

            StreamReader NHAlgoReader = new StreamReader(@"Resources\NHAlgo.txt");
            {
                while ((lineNHAlgo = NHAlgoReader.ReadLine()) != null)
                {
                    if (lineNHAlgo.Contains(KeyCurrentAlgo))
                    {
                        SCurrentAlgo = lineNHAlgo;
                        SCurrentAlgo = getBetween(SCurrentAlgo, ": \"", "\"");
                        break;
                    }
                }
            }

            StreamReader HashRateReader = new StreamReader(@"Resources\HashRates.txt");
            {
                while ((lineHashRate = HashRateReader.ReadLine()) != null)
                {
                    if (lineHashRate.Contains(SCurrentAlgo))
                    {
                        SHashEnd = lineHashRate;
                        SHashEnd = getBetween(SHashEnd, ": \"", "\"");
                        break;
                    }
                }
            }

            SCurrentHashRate = Convert.ToString(CurrentHashRate) + " " + SHashEnd;
            lblWorkerHashv.Text = SCurrentHashRate;
            lblWorkerAlgov.Text = SCurrentAlgo;
            lblWorkerAddress.Text = CurrentNHWallet;
        }
        void GETWorkerNHReject()
        {
            DEfficiency = CurrentRejectRate / CurrentHashRate;
            DEfficiency = DEfficiency * 100;
            DEfficiency = Math.Round(DEfficiency, 0);
            DEfficiency = 100 - DEfficiency;


            GETWorkerInfoNH();

            SCurrentRejectRate = Convert.ToString(CurrentRejectRate) + " " + SHashEnd;
            lblWorkerRejectv.Text = SCurrentRejectRate;

            SEfficiency = Convert.ToString(DEfficiency) + "%";
            lblWorkerEfficiencyv.Text = SEfficiency;
            lblWorkerEfficiencyv.ForeColor = Color.Red;
        }
        void GETWorkerNHProfit()
        {
            RealProfit.Clear();

            string url = @"https://api.nicehash.com/api?method=stats.provider.ex&addr=" + CurrentNHWallet;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                lineWorker = reader.ReadToEnd();
                NHRelProfit = getBetween(lineWorker, ":[", "],\"nh_wallet");
                NHRelProfitA = Regex.Split(NHRelProfit, "},{");
                SepProfit = NHRelProfitA.OfType<string>().ToList();
                for (int x = 0; x < SepProfit.Count; x++)
                {
                    if (SepProfit[x] != "")
                    {
                        NHProfitability = SepProfit[x];
                        NHActualAlgoS = SepProfit[x];
                        NHProfitability = getBetween(NHProfitability, "profitability", ",\"data");
                        NHProfitability = RemoveExtraText(NHProfitability);

                        NHActualAlgoS = RemoveonlyCurly(NHActualAlgoS);
                        NHActualAlgoS = NHActualAlgoS + "}";
                        NHActualAlgoS = getBetween(NHActualAlgoS, "algo", "}");
                        NHActualAlgoS = RemoveExtraText(NHActualAlgoS);
                        NHActualAlgoI = Convert.ToInt32(NHActualAlgoS);

                        RealProfit.Add(NHActualAlgoI, NHProfitability);
                    }
                    else if (SepProfit[x] == "")
                    {
                        break;
                    }

                }
            }
        }
        void GETWorkerCalcProfit()
        {
            NHCalcProfitRate = RealProfit[Convert.ToInt32(SepDATA[5])];
            NHCalcProfitBTCD = Math.Round(Convert.ToDouble(NHCalcProfitRate) * CurrentHashRate, 8);
            if (HeaderMiningCurrencyv.SelectedIndex == 0)
            {
                lblProfitv.Text = Convert.ToString(NHCalcProfitBTCD);
                lblProfitMv.Text = Convert.ToString(Math.Round(NHCalcProfitBTCD * 30.4167, 8));
                lblProfitYv.Text = Convert.ToString(Math.Round(NHCalcProfitBTCD * 365, 8));
                lblProfit.Text = "BTC/DAY";
                lblProfitM.Text = "BTC/MONTH";
                lblProfitY.Text = "BTC/YEAR";
            }
            else if (HeaderMiningCurrencyv.SelectedIndex == 1)
            {
                lblProfitv.Text = "$" + string.Format("{0:#,0.00}", NHCalcProfitBTCD * UniversalBTCPrice);
                lblProfitMv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 30.4167) * UniversalBTCPrice);
                lblProfitYv.Text = "$" + string.Format("{0:#,0.00}", (NHCalcProfitBTCD * 365) * UniversalBTCPrice);
                lblProfit.Text = "USD/DAY";
                lblProfitM.Text = "USD/MONTH";
                lblProfitY.Text = "USD/YEAR";
            }
        }
        void GETWorkerInfo()
        {
            STimeDays = null;
            STimeHours = null;
            STimeMins = null;
            STimeSeconds = null;
            TimeCalc = false;
            WorkerID = HeaderWorkerv.Text;

            if (HeaderPoolv.Text == "NICEHASH")
            {
                for (int x = 0; x < SepWorkers.Count; x++)
                {
                    WorkerID = SepWorkers[x];
                    WorkerID = RemoveforMiningKeepingCurly(WorkerID);
                    int RemoveA = WorkerID.LastIndexOf("{");
                    if (RemoveA > 0)
                    {
                        WorkerID = WorkerID.Substring(0, RemoveA);
                    }
                    else if (RemoveA == 0)
                    {
                        WorkerID = "EMPTY";
                    }

                    if (WorkerID == HeaderWorkerv.Text)
                    {
                        DATA = SepWorkers[x];
                        char last = DATA[DATA.Length - 1];
                        if (last != ']')
                        {
                            DATA = DATA + "]";
                        }
                        break;
                    }
                }

                DATA = getBetween(DATA, ",{\"", "]");
                DATA = RemoveExtraText(DATA);
                WorkerIDCheck = RemoveCommas(DATA);
                Console.WriteLine(DATA);
                Console.WriteLine(WorkerIDCheck);
                SepDATA = DATA.Split(',');

                GETWorkerNHProfit();

                if (SepDATA.Length == 6)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[1]);
                    Verified = SepDATA[2];
                    lblWorkerDifficultyv.Text = SepDATA[3];
                    KeyCurrentAlgo = "\"" + SepDATA[5] + "\"";

                    //Use New Variables to Calculate Displayable Data
                    GETWorkerInfoNH();

                    //Set Leftover Labels
                    lblWorkerRejectv.Text = "0 " + SHashEnd;
                    lblWorkerEfficiencyv.Text = "100%";
                    lblWorkerEfficiencyv.ForeColor = Color.LightGreen;

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 7)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[2]);
                    Verified = SepDATA[3];
                    lblWorkerDifficultyv.Text = SepDATA[4];
                    KeyCurrentAlgo = "\"" + SepDATA[6] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();
                }
                else if (SepDATA.Length == 8)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[3]);
                    Verified = SepDATA[4];
                    lblWorkerDifficultyv.Text = SepDATA[5];
                    KeyCurrentAlgo = "\"" + SepDATA[7] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 9)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]) + Convert.ToDouble(SepDATA[3]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[3]);
                    Verified = SepDATA[5];
                    lblWorkerDifficultyv.Text = SepDATA[6];
                    KeyCurrentAlgo = "\"" + SepDATA[8] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else if (SepDATA.Length == 10)
                {
                    //Setting Array Values to Variables
                    CurrentHashRate = Convert.ToDouble(SepDATA[0]);
                    CurrentRejectRate = Convert.ToDouble(SepDATA[1]) + Convert.ToDouble(SepDATA[2]) + Convert.ToDouble(SepDATA[3]) + Convert.ToDouble(SepDATA[4]);
                    SUpTimeBeforeCalc = Convert.ToDouble(SepDATA[4]);
                    Verified = SepDATA[6];
                    lblWorkerDifficultyv.Text = SepDATA[7];
                    KeyCurrentAlgo = "\"" + SepDATA[9] + "\"";

                    //Use New Variables Including Rejected Speed | Set Labels 
                    GETWorkerNHReject();

                    //Calculate Profitability
                    GETWorkerCalcProfit();
                }
                else
                {
                    //If Nicehash API is Updated this Formula could potentially break
                    MessageBox.Show("NICEHASH API IS DELAYED - PLEASE TRY AGAIN LATER");
                    lblWorkerIDv.Text = "No Data";
                    lblWorkerAlgov.Text = "No Data";
                    lblWorkerDifficultyv.Text = "No Data";
                    lblWorkerUpTimev.Text = "No Data";
                    lblWorkerVerifiedv.Text = "No Data";
                    lblWorkerVerifiedv.ForeColor = Color.Black;
                    lblWorkerEfficiencyv.Text = "No Data";
                    lblWorkerEfficiencyv.ForeColor = Color.Black;
                    lblWorkerHashv.Text = "No Data";
                    lblWorkerRejectv.Text = "No Data";
                    lblProfitv.Text = "No Data";
                }
            }
            SYNCED = true;
        }
        private string RemoveonlyCurly(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890,:[].\"";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        private string RemoveforMining(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        private string RemoveforMiningKeepingCurly(string value)
        {
            var allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890{}";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        private string RemoveCommas(string value)
        {
            var allowedChars = "1234567890.";
            try
            {
                return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
            }
            catch (Exception)
            {
                return value;
            }
        }
        

        private void HeaderPoolv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GETWorkers();
        }

        private void HeaderWorkerv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GETWorkerInfo();
        }
        
        private void OptionsNHWalletsv_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentNHWallet = OptionsNHWalletsv.Text;
            GETWorkers();
        }
        private void HeaderMiningCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HeaderWorkerv.Text != "")
            {
                GETWorkerInfo();
            }
        }





        private void btnOptionsNHDefault_Click(object sender, EventArgs e)
        {
            OptionsNHClick(lblNHDefaultSet);
            GETPools();
        }
        private void btnOptionsNicehashSave_Click(object sender, EventArgs e)
        {
            OptionsNHClick(lblNHWalletSaved);
            GETPools();
        }
        private void btnOptionsNHRemove_Click(object sender, EventArgs e)
        {
            OptionsNHClick(lblNHRemove);
        }

        private void btnOptionsNHClear_Click(object sender, EventArgs e)
        {
            OptionsNHClick(lblNHClear);
        }
        void OptionsNHClick(Label lblNH)
        {
            lblNHWalletSaved.Visible = false;
            lblNHDefaultSet.Visible = false;
            lblNHRemove.Visible = false;
            lblNHClear.Visible = false;
            NHWallets = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt").ToList();
            NewNHWallet = txtOptionsNHv.Text;
            if (lblNH.Name == "lblNHClear")
            {
                DialogResult Result = MessageBox.Show("ARE YOU SURE?", "Confirmation", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    NHWallets.Clear();
                    File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", NHWallets);
                    lblNH.Text = "WALLETS CLEARED";
                    lblNH.Visible = true;
                    GETWallets();
                }
            }
            else
            {
                if (NewNHWallet.Length < 25 || NewNHWallet.Length > 34)
                {
                    lblNH.Text = "INVALID BITCOIN ADDRESS";
                    lblNH.Visible = true;
                }
                else
                {
                    WalletIndexChecker = NHWallets.FindIndex(x => x.StartsWith(NewNHWallet));
                    bool WalletDuplicate = NHWallets.Contains(NewNHWallet);
                    if (WalletDuplicate != true)
                    {
                        if (NewNHWallet != "")
                        {
                            if (lblNH.Name == "lblNHDefaultSet")
                            {
                                NHWallets.Insert(0, NewNHWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", NHWallets);
                                lblNH.Text = "DEFAULT SET";
                                lblNH.Visible = true;
                                GETWallets();
                            }
                            else if (lblNH.Name == "lblNHWalletSaved")
                            {
                                NHWallets.Add(NewNHWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", NHWallets);
                                lblNH.Text = "WALLET SAVED";
                                lblNH.Visible = true;
                                GETWallets();
                            }
                            else if (lblNH.Name == "lblNHRemove")
                            {
                                lblNH.Text = "CANNOT REMOVE NEW WALLET";
                                lblNH.Visible = true;
                            }
                        }
                        else
                        {
                            lblNH.Text = "INPUT IS EMPTY";
                            lblNH.Visible = true;
                        }
                    }
                    else if (lblNH.Name == "lblNHDefaultSet" && WalletIndexChecker == 0)
                    {
                        lblNH.Text = "ALREADY SET TO DEFAULT";
                        lblNH.Visible = true;
                    }
                    else if (lblNH.Name == "lblNHDefaultSet")
                    {
                        if (NewNHWallet != "")
                        {
                            if (lblNH.Name == "lblNHDefaultSet")
                            {
                                NHWallets.Remove(NewNHWallet);
                                NHWallets.Insert(0, NewNHWallet);
                                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", NHWallets);
                                lblNH.Text = "DEFAULT SET";
                                lblNH.Visible = true;
                                GETWallets();
                            }
                            else
                            {
                                lblNH.Text = "INPUT IS EMPTY";
                                lblNH.Visible = true;
                            }
                        }
                    }
                    else if (lblNH.Name == "lblNHWalletSaved")
                    {
                        lblNH.Text = "WALLET ALREADY SAVED";
                        lblNH.Visible = true;
                    }
                    else if (lblNH.Name == "lblNHRemove")
                    {
                        NHWallets.Remove(NewNHWallet);
                        File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Nicehash.txt", NHWallets);
                        lblNH.Text = "WALLET REMOVED";
                        lblNH.Visible = true;
                        GETWallets();
                    }
                }
            }
        }

        private void txtCustomMouse(object sender, EventArgs e)
        {
            txtCustom01.SelectionLength = 0;
            txtCustom02.SelectionLength = 0;
            txtCustom03.SelectionLength = 0;
            txtCustom04.SelectionLength = 0;
            txtCustom05.SelectionLength = 0;
            txtCustom06.SelectionLength = 0;
            txtCustom07.SelectionLength = 0;
            txtCustom08.SelectionLength = 0;
            txtCustom09.SelectionLength = 0;
        }

        private void txtCustomMouse(object sender, MouseEventArgs e)
        {
            txtCustom01.SelectionLength = 0;
            txtCustom02.SelectionLength = 0;
            txtCustom03.SelectionLength = 0;
            txtCustom04.SelectionLength = 0;
            txtCustom05.SelectionLength = 0;
            txtCustom06.SelectionLength = 0;
            txtCustom07.SelectionLength = 0;
            txtCustom08.SelectionLength = 0;
            txtCustom09.SelectionLength = 0;
        }

        private void btnMiningSettings_Click(object sender, EventArgs e)
        {
            StartingMiningSettings.Clear();
            StartingMiningSettings.Add(HeaderPoolv.Text);
            StartingMiningSettings.Add(HeaderWorkerv.Text);
            StartingMiningSettings.Add(Convert.ToString(HeaderMiningCurrencyv.SelectedIndex));
            File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Mining\Default.txt", StartingMiningSettings);
        }
    }
}
