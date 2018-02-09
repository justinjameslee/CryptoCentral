using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Web;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace APIAccessTEST01
{
    public partial class Crypto : Form
    {
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
        List<string> CurrencyList = new List<string> { "aud", "usd", "jpy", "krw" };

        string CURRENCY;
        string COIN;
        string CRYPTO;
        string jsonString;

        private void Crypto_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1015, 457);
            btnClose.Location = new Point(798, 12);
            lblBack.Location = new Point(65, 416);
            btnBack.Location = new Point(12, 416);
            this.CenterToScreen();
            GETINFOUSD("bitcoin", "BTC", lblCustomUSDv01, lblCustomBTCv01, lblCustom1Hc01, lblCustom24Hc01, lblCustom7Dc01, lblCustom1Hp01, lblCustom24Hp01, lblCustom7Dp01, lblCustomUSD01, lblCustomBTC01);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD("ethereum", "ETH", lblCustomUSDv02, lblCustomBTCv02, lblCustom1Hc02, lblCustom24Hc02, lblCustom7Dc02, lblCustom1Hp02, lblCustom24Hp02, lblCustom7Dp02, lblCustomUSD02, lblCustomBTC02);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD("litecoin", "LTC", lblCustomUSDv03, lblCustomBTCv03, lblCustom1Hc03, lblCustom24Hc03, lblCustom7Dc03, lblCustom1Hp03, lblCustom24Hp03, lblCustom7Dp03, lblCustomUSD03, lblCustomBTC03);
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

        void GETINFOUSD(string CRYPTO, string customCoin, Label xUSDv, Label xBTCv, Label xUSDc, Label xUSD24c, Label xUSD7c, Label xUSDp, Label xUSD24p, Label xUSD7p, Label xUSD, Label xBTC)
        {
            API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO);

            CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

            xUSD.Text = customCoin + "/USD";
            xBTC.Text = customCoin + "/BTC";

            foreach (var data in CoinsDetailed)             //Get Value of BTC
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
                    xUSDv.ForeColor = Color.LightGreen;
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

            foreach (var data in CoinsDetailed)         //WIP
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
                    else { xBTCv.ForeColor = Color.LightGreen; }
                }
                else if (Dchange < 0)
                {
                    if (data.symbol == "BTC") { }
                    else { xBTCv.ForeColor = Color.Red; }
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
                if (DChange < 0)
                {
                    DChange = DChange * -1;
                    DChange = Dprice_usd - DChange;
                    xUSDc.ForeColor = Color.Red;
                }
                else if (DChange > 0)
                {
                    DChange = Dprice_usd - DChange;
                    if (DChange == 0)
                    {
                        xUSDc.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        xUSDc.ForeColor = Color.LightGreen;
                    }

                }
                value_changed = Convert.ToString(DChange);
                value_changed = value_changed.Substring(0, 8);
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
                if (DChange < 0)
                {
                    DChange = DChange * -1;
                    DChange = Dprice_usd - DChange;
                    xUSD24c.ForeColor = Color.Red;
                }
                else if (DChange > 0)
                {
                    DChange = Dprice_usd - DChange;
                    if (DChange == 0)
                    {
                        xUSD24c.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        xUSD24c.ForeColor = Color.LightGreen;
                    }

                }
                value_changed = Convert.ToString(DChange);
                value_changed = value_changed.Substring(0, 8);
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
                if (DChange < 0)
                {
                    DChange = DChange * -1;
                    DChange = Dprice_usd - DChange;
                    xUSD7c.ForeColor = Color.Red;
                }
                else if (DChange > 0)
                {
                    DChange = Dprice_usd - DChange;
                    if (DChange == 0)
                    {
                        xUSD7c.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        xUSD7c.ForeColor = Color.LightGreen;
                    }

                }
                value_changed = Convert.ToString(DChange);
                value_changed = value_changed.Substring(0, 8);
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
                    xUSDp.ForeColor = Color.LightGreen;
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
                    xUSD24p.ForeColor = Color.LightGreen;
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
                    xUSD7p.ForeColor = Color.LightGreen;
                }
                else if (Dchange < 0)
                {
                    xUSD7p.ForeColor = Color.Red;
                }
                else if (Dchange == 0)
                {
                    xUSD7p.ForeColor = Color.Yellow;
                }
                xUSD7p.Text = percent_change_7d;
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
    }
}
