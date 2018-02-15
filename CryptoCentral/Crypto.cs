using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        List<MarketCap> Coins;
        List<MarketCap> CoinsDetailed;

        string CURRENCY;
        string jsonString;

        string coin1 = "";
        string coin2 = "";
        string coin3 = "";
        string coin4 = "";
        string coin5 = "";
        string coin6 = "";
        string coin7 = "";
        string coin8 = "";
        string coin9 = "";

        string coin1FN = "";
        string coin2FN = "";
        string coin3FN = "";
        string coin4FN = "";
        string coin5FN = "";
        string coin6FN = "";
        string coin7FN = "";
        string coin8FN = "";
        string coin9FN = "";

        string PageNumber;
        string Pages;
        string StartingCurrency;

        string[] Profile1 = { "", "", "", "", "", "", "", "", "", "" };
        public string[] Profile1Loaded = new string[10];

        bool bOptions = false;
        bool bSummary = true;
        bool bMining = false;
        bool ConfirmAllowed = false;
        bool ProfileLoaded = false;
        bool NewSave;

        double Profile;

        int pages = 1;
        int PageCalculation;
        int CurrentPage;

        int MaxPages;
        int CurrencyNumber;

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
        }
        void CreateMustFiles()
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile));
                Pages = Convert.ToString(pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt", Pages);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt", Convert.ToString(0));
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Page0.txt", Profile1);
                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", Convert.ToString(0));
            }
            else
            {

            }
        }
        private void Crypto_Load(object sender, EventArgs e)
        {
            ProfileLoaded = false;
            Profile = 1;
            CreateMustFiles();
            LoadProfile(Profile);
            TestCoinSummary();
            Summary01RESET();
            HeaderDefaultRESET();
            Pagev.SelectedIndex = Convert.ToInt32(PageNumber);
            Options.Visible = false;
            Mining01.Visible = false;
            Summary01.Visible = true;
            this.Size = new Size(1064, 546);
            this.CenterToScreen();
            GETINFOSummary();
            lblSaveFound.Visible = false;
        }
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
            lblHeaderCurrency.Visible = true;
            HeaderCurrencyv.Visible = true;
        }
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
        void LoadProfile(double ProfileNumber)
        {
            if (ProfileNumber == 1)
            {
                try
                {
                    StartingCurrency = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt");
                    PageNumber = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\PageStart.txt");
                    Pages = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Pages.txt");
                    CurrencyNumber = Convert.ToInt32(StartingCurrency);
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
                    ProfileLoaded = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR");
                }
                
            }
        }
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
        void UpdatingCurrentPage()
        {
            CurrentPage = Pagev.SelectedIndex + 1;
            lblCurrentPage.Text = "PAGE " + Convert.ToString(CurrentPage);
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
        public void TestOptionCoins(ref string RealCoin, ref string RealCoinFN)
        {
            API(@"https://api.coinmarketcap.com/v1/ticker/");

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
                    else if (counting == 100)
                    {
                        RealCoin = "";
                        RealCoinFN = "";
                    }
                }
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

                if (Currencyv.SelectedIndex == 0)
                {
                    xC.Text = customCoin + "/USD";
                    foreach (var data in CoinsDetailed)             //Coin Against USD
                    {
                        string price_usd;
                        string percent;
                        double Dpercent;
                        price_usd = data.price_usd;
                        price_usd = RemoveExtraText(price_usd);
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
                        newprice = Math.Round(newprice, 2);
                        price_aud = string.Format("{0:0,0.00}", newprice);
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
                    }
                }
                xBTC.Text = customCoin + "/BTC";
                Number.Text = customCoin;

                foreach (var data in CoinsDetailed)         //Calculate Last Updated Time.
                {
                    string Time;
                    string FinalTime;
                    double DTime;
                    Time = data.last_updated;
                    Time = RemoveExtraText(Time);
                    DTime = Convert.ToDouble(Time);
                    FinalTime = String.Format("{0:d/M/yyyy HH:mm:ss}", new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(DTime));
                    xTimev.Text = FinalTime + " UTC";
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
                }
                foreach (var data in CoinsDetailed)         //Change 1Hour BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    string price_aud;
                    double Dprice_aud;
                    double DChange;

                    convertedPercent = data.percent_change_1h;
                    convertedPercent = RemoveExtraText(convertedPercent);
                    if (CURRENCY == "USD")
                    {
                        price_usd = data.price_usd;
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
                        Dprice_usd = Convert.ToDouble(data.price_usd);
                        DChange = Dprice_usd / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSDc.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSDc.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSDc.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSDc.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSDc.Text = value_changed;
                    }
                    else if (CURRENCY == "AUD")
                    {
                        price_aud = data.price_aud;
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
                        Dprice_aud = Convert.ToDouble(data.price_aud);
                        DChange = Dprice_aud / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSDc.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSDc.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSDc.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSDc.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSDc.Text = value_changed;
                    }
                }
                foreach (var data in CoinsDetailed)         //Change 24Hour BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    string price_aud;
                    double Dprice_aud;
                    double DChange;

                    convertedPercent = data.percent_change_24h;
                    convertedPercent = RemoveExtraText(convertedPercent);
                    if (CURRENCY == "USD")
                    {
                        price_usd = data.price_usd;
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
                        Dprice_usd = Convert.ToDouble(data.price_usd);
                        DChange = Dprice_usd / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD24c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD24c.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD24c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD24c.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSD24c.Text = value_changed;
                    }
                    else if (CURRENCY == "AUD")
                    {
                        price_aud = data.price_aud;
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
                        Dprice_aud = Convert.ToDouble(data.price_aud);
                        DChange = Dprice_aud / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD24c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD24c.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD24c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD24c.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSD24c.Text = value_changed;
                    }
                }
                foreach (var data in CoinsDetailed)         //Change 7Day BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    string price_aud;
                    double Dprice_aud;
                    double DChange;

                    convertedPercent = data.percent_change_7d;
                    convertedPercent = RemoveExtraText(convertedPercent);
                    if (CURRENCY == "USD")
                    {
                        price_usd = data.price_usd;
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
                        Dprice_usd = Convert.ToDouble(data.price_usd);
                        DChange = Dprice_usd / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD7c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD7c.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_usd - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD7c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD7c.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSD7c.Text = value_changed;
                    }
                    else if (CURRENCY == "AUD")
                    {
                        price_aud = data.price_aud;
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
                        Dprice_aud = Convert.ToDouble(data.price_aud);
                        DChange = Dprice_aud / totalPercent;
                        value_changed = Convert.ToString(DChange);
                        if (DChange < 0)
                        {
                            DChange = DChange * -1;
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD7c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD7c.ForeColor = Color.Red;
                                value_changed = value_changed.Substring(0, 8);
                            }
                        }
                        else if (DChange > 0)
                        {
                            DChange = Dprice_aud - DChange;
                            value_changed = Convert.ToString(DChange);
                            if (DChange == 0)
                            {
                                xUSD7c.ForeColor = Color.White;
                            }
                            else
                            {
                                xUSD7c.ForeColor = Color.Green;
                                value_changed = value_changed.Substring(0, 8);
                            }

                        }
                        value_changed = "$" + value_changed;
                        xUSD7c.Text = value_changed;
                    }
                }
                foreach (var data in CoinsDetailed)             //Change 1Hour BTC PERCENT
                {
                    string percent_change_1h;
                    double Dchange;
                    percent_change_1h = data.percent_change_1h;
                    percent_change_1h = RemoveExtraText(percent_change_1h);
                    Dchange = Convert.ToDouble(percent_change_1h);
                    percent_change_1h = percent_change_1h + "%";
                    if (Dchange > 0)
                    {
                        xUSDp.ForeColor = Color.Green;
                    }
                    else if (Dchange < 0)
                    {
                        xUSDp.ForeColor = Color.Red;
                    }
                    else if (Dchange == 0)
                    {
                        xUSDp.ForeColor = Color.White;
                    }
                    xUSDp.Text = percent_change_1h;
                }
                foreach (var data in CoinsDetailed)             //Change 24Hour BTC PERCENT
                {
                    double Dchange;
                    string percent_change_24h;
                    percent_change_24h = data.percent_change_24h;
                    percent_change_24h = RemoveExtraText(percent_change_24h);
                    Dchange = Convert.ToDouble(percent_change_24h);
                    percent_change_24h = percent_change_24h + "%";
                    if (Dchange > 0)
                    {
                        xUSD24p.ForeColor = Color.Green;
                    }
                    else if (Dchange < 0)
                    {
                        xUSD24p.ForeColor = Color.Red;
                    }
                    else if (Dchange == 0)
                    {
                        xUSD24p.ForeColor = Color.White;
                    }
                    xUSD24p.Text = percent_change_24h;
                }
                foreach (var data in CoinsDetailed)             //Change 7Days BTC PERCENT
                {
                    double Dchange;
                    string percent_change_7d;
                    percent_change_7d = data.percent_change_7d;
                    percent_change_7d = RemoveExtraText(percent_change_7d);
                    Dchange = Convert.ToDouble(percent_change_7d);
                    percent_change_7d = percent_change_7d + "%";
                    if (Dchange > 0)
                    {
                        xUSD7p.ForeColor = Color.Green;
                    }
                    else if (Dchange < 0)
                    {
                        xUSD7p.ForeColor = Color.Red;
                    }
                    else if (Dchange == 0)
                    {
                        xUSD7p.ForeColor = Color.White;
                    }
                    xUSD7p.Text = percent_change_7d;
                }
            }
            
        }

        private string RemoveExtraText(string value)
        {
            var allowedChars = "01234567890.,-";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
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
                MessageBox.Show("Recalibrating...");
            }
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            GETINFOSummary();
        }
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
        void EditSummary()
        {
            txtCustom01.ReadOnly = false;
            txtCustom02.ReadOnly = false;
            txtCustom03.ReadOnly = false;
            txtCustom04.ReadOnly = false;
            txtCustom05.ReadOnly = false;
            txtCustom06.ReadOnly = false;
            txtCustom07.ReadOnly = false;
            txtCustom08.ReadOnly = false;
            txtCustom09.ReadOnly = false;
            txtCustom01.BackColor = Color.DarkGray;
            txtCustom02.BackColor = Color.DarkGray;
            txtCustom03.BackColor = Color.DarkGray;
            txtCustom04.BackColor = Color.DarkGray;
            txtCustom05.BackColor = Color.DarkGray;
            txtCustom06.BackColor = Color.DarkGray;
            txtCustom07.BackColor = Color.DarkGray;
            txtCustom08.BackColor = Color.DarkGray;
            txtCustom09.BackColor = Color.DarkGray;
            ConfirmAllowed = true;
            ProfileLoaded = false;
        }
        void ConfirmSummary()
        {
            while (ConfirmAllowed == true)
            {
                txtCustom01.ReadOnly = true;
                txtCustom02.ReadOnly = true;
                txtCustom03.ReadOnly = true;
                txtCustom04.ReadOnly = true;
                txtCustom05.ReadOnly = true;
                txtCustom06.ReadOnly = true;
                txtCustom07.ReadOnly = true;
                txtCustom08.ReadOnly = true;
                txtCustom09.ReadOnly = true;
                txtCustom01.BackColor = Color.Gray;
                txtCustom02.BackColor = Color.Gray;
                txtCustom03.BackColor = Color.Gray;
                txtCustom04.BackColor = Color.Gray;
                txtCustom05.BackColor = Color.Gray;
                txtCustom06.BackColor = Color.Gray;
                txtCustom07.BackColor = Color.Gray;
                txtCustom08.BackColor = Color.Gray;
                txtCustom09.BackColor = Color.Gray;
                lblConfirmed.Visible = true;
                TestCoinSummary();
                GETINFOSummary();
                ConfirmAllowed = false;
            }
        }
        void GETINFOSummary()
        {
            GETINFO(coin1FN, coin1, lblCustomCv01, lblCustomBTCv01, lblCustom1Hc01, lblCustom24Hc01, lblCustom7Dc01, lblCustom1Hp01, lblCustom24Hp01, lblCustom7Dp01, lblCustomC01, lblCustomBTC01, lblCustomUpdatedv01, customGroup01);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin2FN, coin2, lblCustomCv02, lblCustomBTCv02, lblCustom1Hc02, lblCustom24Hc02, lblCustom7Dc02, lblCustom1Hp02, lblCustom24Hp02, lblCustom7Dp02, lblCustomC02, lblCustomBTC02, lblCustomUpdatedv02, customGroup02);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin3FN, coin3, lblCustomCv03, lblCustomBTCv03, lblCustom1Hc03, lblCustom24Hc03, lblCustom7Dc03, lblCustom1Hp03, lblCustom24Hp03, lblCustom7Dp03, lblCustomC03, lblCustomBTC03, lblCustomUpdatedv03, customGroup03);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin4FN, coin4, lblCustomCv04, lblCustomBTCv04, lblCustom1Hc04, lblCustom24Hc04, lblCustom7Dc04, lblCustom1Hp04, lblCustom24Hp04, lblCustom7Dp04, lblCustomC04, lblCustomBTC04, lblCustomUpdatedv04, customGroup04);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin5FN, coin5, lblCustomCv05, lblCustomBTCv05, lblCustom1Hc05, lblCustom24Hc05, lblCustom7Dc05, lblCustom1Hp05, lblCustom24Hp05, lblCustom7Dp05, lblCustomC05, lblCustomBTC05, lblCustomUpdatedv05, customGroup05);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin6FN, coin6, lblCustomCv06, lblCustomBTCv06, lblCustom1Hc06, lblCustom24Hc06, lblCustom7Dc06, lblCustom1Hp06, lblCustom24Hp06, lblCustom7Dp06, lblCustomC06, lblCustomBTC06, lblCustomUpdatedv06, customGroup06);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin7FN, coin7, lblCustomCv07, lblCustomBTCv07, lblCustom1Hc07, lblCustom24Hc07, lblCustom7Dc07, lblCustom1Hp07, lblCustom24Hp07, lblCustom7Dp07, lblCustomC07, lblCustomBTC07, lblCustomUpdatedv07, customGroup07);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin8FN, coin8, lblCustomCv08, lblCustomBTCv08, lblCustom1Hc08, lblCustom24Hc08, lblCustom7Dc08, lblCustom1Hp08, lblCustom24Hp08, lblCustom7Dp08, lblCustomC08, lblCustomBTC08, lblCustomUpdatedv08, customGroup08);
            System.Threading.Thread.Sleep(50);
            GETINFO(coin9FN, coin9, lblCustomCv09, lblCustomBTCv09, lblCustom1Hc09, lblCustom24Hc09, lblCustom7Dc09, lblCustom1Hp09, lblCustom24Hp09, lblCustom7Dp09, lblCustomC09, lblCustomBTC09, lblCustomUpdatedv09, customGroup09);
        }
        void TestCoinSummary()
        {
            ConfirmOptionCoins();
            TestOptionCoins(ref coin1, ref coin1FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin2, ref coin2FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin3, ref coin3FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin4, ref coin4FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin5, ref coin5FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin6, ref coin6FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin7, ref coin7FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin8, ref coin8FN);
            System.Threading.Thread.Sleep(50);
            TestOptionCoins(ref coin9, ref coin9FN);
            System.Threading.Thread.Sleep(50);
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
        void EmptySummary()
        {
            txtCustom01.ReadOnly = true;
            txtCustom02.ReadOnly = true;
            txtCustom03.ReadOnly = true;
            txtCustom04.ReadOnly = true;
            txtCustom05.ReadOnly = true;
            txtCustom06.ReadOnly = true;
            txtCustom07.ReadOnly = true;
            txtCustom08.ReadOnly = true;
            txtCustom09.ReadOnly = true;
            txtCustom01.BackColor = Color.Gray;
            txtCustom02.BackColor = Color.Gray;
            txtCustom03.BackColor = Color.Gray;
            txtCustom04.BackColor = Color.Gray;
            txtCustom05.BackColor = Color.Gray;
            txtCustom06.BackColor = Color.Gray;
            txtCustom07.BackColor = Color.Gray;
            txtCustom08.BackColor = Color.Gray;
            txtCustom09.BackColor = Color.Gray;
            txtCustom01.Text = "";
            txtCustom02.Text = "";
            txtCustom03.Text = "";
            txtCustom04.Text = "";
            txtCustom05.Text = "";
            txtCustom06.Text = "";
            txtCustom07.Text = "";
            txtCustom08.Text = "";
            txtCustom09.Text = "";
            TestCoinSummary();
            GETINFOSummary();
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

        private void Currencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GETINFOSummary();
            HeaderCurrencyv.SelectedIndex = Currencyv.SelectedIndex;
            lblDefaultSet.Visible = false;
        }

        //void GETHOVERINFO(string customCoin, string CRYPTO, TextBox txtHover)
        //{
        //    if (customCoin == "")
        //    {
        //        txtHover.Text = "No Data" + Environment.NewLine + "No Data" + Environment.NewLine + "No Data";
        //    }
        //    else
        //    {
        //        API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO);

        //        CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

        //        foreach (var data in CoinsDetailed)             //Rank
        //        {
        //            string rank;
        //            rank = data.rank;
        //            Console.WriteLine(rank);
        //            rank = "Rank: " + rank;

        //            double volume_usd;
        //            string volume_usdString;
        //            volume_usd = data.DailyVolumeUSD;
        //            volume_usdString = String.Format("{0:n}", volume_usd);
        //            volume_usdString = "24Hr Volume USD: $" + volume_usdString;

        //            double marketcap_usd;
        //            string marketcap_usdString;
        //            marketcap_usd = data.market_cap_usd;
        //            marketcap_usdString = String.Format("{0:n}", marketcap_usd);
        //            marketcap_usdString = "Market Cap USD: $" + marketcap_usdString;

        //            txtHover.Text = rank + Environment.NewLine + volume_usdString + Environment.NewLine + marketcap_usdString;
        //        }
        //    }
        //}
        private void event_SummaryHover(object sender, EventArgs e)
        {
            //txtHoverInfo.Visible = true;
            //string HoverCoin = ((GroupBox)sender).Text;
            //string HoverCoinFN = "";
            //TestOptionCoins(ref HoverCoin, ref HoverCoinFN);
            //GETHOVERINFO(HoverCoin, HoverCoinFN, txtHoverInfo);
            //txtHoverInfo.Location = new Point(Cursor.Position.X - 605, Cursor.Position.Y - 325);
        }

        private void timerUpdating_Tick(object sender, EventArgs e)
        {

        }

        private void HeaderCurrencyv_SelectedIndexChanged(object sender, EventArgs e)
        {
            Currencyv.SelectedIndex = HeaderCurrencyv.SelectedIndex;
        }

        private void btnCurrencyDefault_Click(object sender, EventArgs e)
        {
            StartingCurrency = Convert.ToString(Currencyv.SelectedIndex);
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\" + Convert.ToString(Profile) + @"\Currency.txt", StartingCurrency);
            lblDefaultSet.Visible = true;
        }











        //MINING

    }
}
