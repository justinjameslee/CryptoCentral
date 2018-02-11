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
        public Crypto()
        {
            InitializeComponent();
        }

        Color BrightRed = ColorTranslator.FromHtml("#FF0000");

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        List<MarketCap> Coins;
        List<MarketCap> CoinsDetailed;
        List<string> CurrencyList = new List<string> { "aud", "usd", "jpy", "krw" };

        string CURRENCY;
        string COIN;
        string CRYPTO;
        string jsonString;
        string line;

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

        string[] Profile1 = new string[9];
        string[] Profile1Loaded = new string[9];

        bool bOptions = false;
        bool bSummary = true;
        bool ConfirmAllowed = false;
        bool ProfileLoaded = false;

        double Profile;

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
        private void Crypto_Load(object sender, EventArgs e)
        {
            ProfileLoaded = false;
            Profile = 1;
            LoadProfile(Profile);
            TestCoinSummary();
            Summary01RESET();
            Options.Visible = false;
            Summary01.Visible = true;
            this.Size = new Size(1064, 546);
            this.CenterToScreen();
            GETINFOSummary();
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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (bOptions == true)
            {
                bOptions = false;
                bSummary = true;
                Summary01RESET();
                Summary01.Visible = true;
                Options.Visible = false;
                lblSaved.Visible = false;
                lblConfirmed.Visible = false;
            }
        }
        private void lblSettings_Click(object sender, EventArgs e)
        {
            bOptions = true;
            bSummary = false;
            OptionsRESET();
            Summary01.Visible = false;
            Options.Visible = true;
        }
        void LoadProfile(double ProfileNumber)
        {
            if (ProfileNumber == 1)
            {
                Profile1Loaded = File.ReadAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\Profile1.txt");
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
                ProfileLoaded = true;
            }
        }
        void ConfirmOptionCoins()
        {
            if (ProfileLoaded != true)
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
            else
            {

            }
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
                Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles");
                File.WriteAllLines(@"C:\Users\" + Environment.UserName + @"\Documents\CryptoCentral\Profiles\Profile1.txt", Profile1);
            }
        }
        public void TestOptionCoins(ref string RealCoin, ref string RealCoinFN)
        {
            API(@"https://api.coinmarketcap.com/v1/ticker/");

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
                }
            }
        }
        void GETINFOUSD(string CRYPTO, string customCoin, Label xUSDv, Label xBTCv, Label xUSDc, Label xUSD24c, Label xUSD7c, Label xUSDp, Label xUSD24p, Label xUSD7p, Label xUSD, Label xBTC, Label xTimev, GroupBox Number)
        {
            if(CRYPTO == "" || customCoin == "")
            {
                xUSD.Text = "XXX/USD";
                xBTC.Text = "XXX/BTC";
                xUSDv.Text = "No Data";
                xBTCv.Text = "No Data";
                xUSDp.Text = "No Data";
                xUSD24p.Text = "No Data";
                xUSD7p.Text = "No Data";
                xUSDc.Text = "";
                xUSD24c.Text = "";
                xUSD7c.Text = "";
                Number.Text = "XXX";
                xTimev.Text = "No Data";

                xUSDv.ForeColor = Color.White;
                xBTCv.ForeColor = Color.White;
                xUSDp.ForeColor = Color.White;
                xUSD24p.ForeColor = Color.White;
                xUSD7p.ForeColor = Color.White;
            }
            else
            {
                API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO);

                CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

                xUSD.Text = customCoin + "/USD";
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
                        xUSDv.ForeColor = Color.Green;
                    }
                    else if (Dpercent < 0)
                    {
                        price_usd = "▼ " + price_usd;
                        xUSDv.ForeColor = Color.Red;
                    }
                    else if (Dpercent == 0)
                    {
                        xUSDv.ForeColor = Color.Yellow;
                    }
                    xUSDv.Text = price_usd;
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
                        if (data.symbol == "BTC") { }
                        else { xBTCv.ForeColor = Color.Green; }
                    }
                    else if (Dchange < 0)
                    {
                        if (data.symbol == "BTC") { }
                        else { xBTCv.ForeColor = BrightRed; }
                    }
                    else if (Dchange == 0)
                    {
                        if (data.symbol == "BTC") { }
                        else { xBTCv.ForeColor = Color.Yellow; }
                    }
                    string price_btc;
                    price_btc = data.price_btc;
                    price_btc = RemoveExtraText(price_btc);
                    price_btc = price_btc + " BTC";
                    xBTCv.Text = price_btc;
                }
                foreach (var data in CoinsDetailed)         //Change 1Hour BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    double DChange;

                    convertedPercent = data.percent_change_1h;
                    convertedPercent = RemoveExtraText(convertedPercent);
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
                            xUSDc.ForeColor = Color.Yellow;
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
                            xUSDc.ForeColor = Color.Yellow;
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
                foreach (var data in CoinsDetailed)         //Change 24Hour BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    double DChange;

                    convertedPercent = data.percent_change_24h;
                    convertedPercent = RemoveExtraText(convertedPercent);
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
                            xUSD24c.ForeColor = Color.Yellow;
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
                            xUSD24c.ForeColor = Color.Yellow;
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
                foreach (var data in CoinsDetailed)         //Change 7Day BTC VALUE
                {
                    string value_changed;
                    string convertedPercent;
                    string price_usd;
                    double Dprice_usd;
                    double DChange;

                    convertedPercent = data.percent_change_7d;
                    convertedPercent = RemoveExtraText(convertedPercent);
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
                            xUSD7c.ForeColor = Color.Yellow;
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
                            xUSD7c.ForeColor = Color.Yellow;
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
                        xUSDp.ForeColor = Color.Yellow;
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
                        xUSD24p.ForeColor = Color.Yellow;
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
                        xUSD7p.ForeColor = BrightRed;
                    }
                    else if (Dchange == 0)
                    {
                        xUSD7p.ForeColor = Color.Yellow;
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

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            GETINFOSummary();
        }
        private void btnEditSummary_Click(object sender, EventArgs e)
        {
            EditSummary();
        }

        private void btnConfirmSummary_Click(object sender, EventArgs e)
        {
            ConfirmSummary();
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
            lblConfirmed.Visible = true;
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
                TestCoinSummary();
                GETINFOSummary();
                ConfirmAllowed = false;
            }
        }
        void GETINFOSummary()
        {
            GETINFOUSD(coin1FN, coin1, lblCustomUSDv01, lblCustomBTCv01, lblCustom1Hc01, lblCustom24Hc01, lblCustom7Dc01, lblCustom1Hp01, lblCustom24Hp01, lblCustom7Dp01, lblCustomUSD01, lblCustomBTC01, lblCustomUpdatedv01, customGroup01);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin2FN, coin2, lblCustomUSDv02, lblCustomBTCv02, lblCustom1Hc02, lblCustom24Hc02, lblCustom7Dc02, lblCustom1Hp02, lblCustom24Hp02, lblCustom7Dp02, lblCustomUSD02, lblCustomBTC02, lblCustomUpdatedv02, customGroup02);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin3FN, coin3, lblCustomUSDv03, lblCustomBTCv03, lblCustom1Hc03, lblCustom24Hc03, lblCustom7Dc03, lblCustom1Hp03, lblCustom24Hp03, lblCustom7Dp03, lblCustomUSD03, lblCustomBTC03, lblCustomUpdatedv03, customGroup03);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin4FN, coin4, lblCustomUSDv04, lblCustomBTCv04, lblCustom1Hc04, lblCustom24Hc04, lblCustom7Dc04, lblCustom1Hp04, lblCustom24Hp04, lblCustom7Dp04, lblCustomUSD04, lblCustomBTC04, lblCustomUpdatedv04, customGroup04);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin5FN, coin5, lblCustomUSDv05, lblCustomBTCv05, lblCustom1Hc05, lblCustom24Hc05, lblCustom7Dc05, lblCustom1Hp05, lblCustom24Hp05, lblCustom7Dp05, lblCustomUSD05, lblCustomBTC05, lblCustomUpdatedv05, customGroup05);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin6FN, coin6, lblCustomUSDv06, lblCustomBTCv06, lblCustom1Hc06, lblCustom24Hc06, lblCustom7Dc06, lblCustom1Hp06, lblCustom24Hp06, lblCustom7Dp06, lblCustomUSD06, lblCustomBTC06, lblCustomUpdatedv06, customGroup06);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin7FN, coin7, lblCustomUSDv07, lblCustomBTCv07, lblCustom1Hc07, lblCustom24Hc07, lblCustom7Dc07, lblCustom1Hp07, lblCustom24Hp07, lblCustom7Dp07, lblCustomUSD07, lblCustomBTC07, lblCustomUpdatedv07, customGroup07);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin8FN, coin8, lblCustomUSDv08, lblCustomBTCv08, lblCustom1Hc08, lblCustom24Hc08, lblCustom7Dc08, lblCustom1Hp08, lblCustom24Hp08, lblCustom7Dp08, lblCustomUSD08, lblCustomBTC08, lblCustomUpdatedv08, customGroup08);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD(coin9FN, coin9, lblCustomUSDv09, lblCustomBTCv09, lblCustom1Hc09, lblCustom24Hc09, lblCustom7Dc09, lblCustom1Hp09, lblCustom24Hp09, lblCustom7Dp09, lblCustomUSD09, lblCustomBTC09, lblCustomUpdatedv09, customGroup09);
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

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
            lblSaved.Visible = true;
            lblSaved.Text = "Saved to Profile " + Convert.ToString(Profile);
        }
    }
}
