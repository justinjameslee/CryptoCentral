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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<MarketCap> Coins;
        List<MarketCap> CoinsDetailed;
        List<string> CurrencyList = new List<string> { "aud", "usd", "jpy", "krw" };

        string CURRENCY;
        string COIN;
        string CRYPTO;
        string price;
        string jsonString;
        string coinSymbol;
        double DoublePrice;

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

        private void button1_Click(object sender, EventArgs e)
        {
            API(@"https://api.coinmarketcap.com/v1/ticker/");

            Coins = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);
            
            foreach (var coin in Coins)
            {
                if (coin.name.ToUpper() == CoinSearch.Text.ToUpper())
                {
                    COIN = coin.symbol;
                    CRYPTO = coin.id.ToLower();
                    break;
                }
                else if (coin.symbol.ToUpper() == CoinSearch.Text.ToUpper())
                {
                    COIN = coin.symbol;
                    CRYPTO = coin.id.ToLower();
                    break;
                }
                COIN = "";
            }

            if(COIN == "")
            {
                MessageBox.Show("Coin does not exist or is not currently supported!");
            }
            else
            {
                API(@"https://api.coinmarketcap.com/v1/ticker/" + CRYPTO + "/?convert=" + CURRENCY);

                CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

                foreach (var data in CoinsDetailed)         //OtherCurrencies + Coins
                {
                    if (CoinSearch.Text == "BTC" && CURRENCY == "usd")
                    {
                        GETINFOUSD("bitcoin", lblBTCUSDv, lblBTCBTCv, lblBTCUSDc, lblBTCUSD24c, lblBTCUSD7c, lblBTCUSDp, lblBTCUSD24p, lblBTCUSD7p);
                    }
                    else
                    {
                        if (CURRENCY == "jpy")
                        {
                            string price_jpy;
                            double newprice;
                            price_jpy = data.price_jpy;
                            price_jpy = RemoveExtraText(price_jpy);
                            newprice = Convert.ToDouble(price_jpy);
                            newprice = Math.Round(newprice, 0);
                            price_jpy = string.Format("{0:n0}", newprice);
                            price_jpy = "¥" + price_jpy;
                            lblCoinCurrency.Text = COIN + "/" + CURRENCY.ToUpper();
                            lblCoinCurrency.Visible = true;
                            lblCoinCurrencyv.Text = price_jpy;
                        }
                        else if (CURRENCY == "aud")
                        {
                            string price_aud;
                            double newprice;
                            price_aud = data.price_aud;
                            price_aud = RemoveExtraText(price_aud);
                            newprice = Convert.ToDouble(price_aud);
                            newprice = Math.Round(newprice, 2);
                            price_aud = string.Format("{0:0,0.00}", newprice);
                            price_aud = "$" + price_aud;
                            lblCoinCurrency.Text = COIN + "/" + CURRENCY.ToUpper();
                            lblCoinCurrency.Visible = true;
                            lblCoinCurrencyv.Text = price_aud;
                        }
                        else if (CURRENCY == "usd")
                        {
                            string price_usd;
                            double newprice;
                            price_usd = data.price_usd;
                            price_usd = RemoveExtraText(price_usd);
                            newprice = Convert.ToDouble(price_usd);
                            newprice = Math.Round(newprice, 2);
                            price_usd = string.Format("{0:0,0.00}", newprice);
                            price_usd = "$" + price_usd;
                            lblCoinCurrency.Text = COIN + "/" + CURRENCY.ToUpper();
                            lblCoinCurrency.Visible = true;
                            lblCoinCurrencyv.Text = price_usd;
                        }
                        string price_btc;
                        price_btc = data.price_btc;
                        price_btc = RemoveExtraText(price_btc);
                        price_btc = price_btc + " BTC";
                        lblCoinBTCv.Text = price_btc;

                    }
                }



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DropdownCurrency.SelectedIndex = 0;
            GETINFOUSD("bitcoin", lblBTCUSDv, lblBTCBTCv, lblBTCUSDc, lblBTCUSD24c, lblBTCUSD7c, lblBTCUSDp, lblBTCUSD24p, lblBTCUSD7p);
            System.Threading.Thread.Sleep(50);
            GETINFOUSD("ethereum", lblETHUSDv, lblETHBTCv, lblETHUSDc, lblETHUSD24c, lblETHUSD7c, lblETHUSDp, lblETHUSD24p, lblETHUSD7p);
        }
        private void DropdownCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropdownCurrency.SelectedIndex == 1)
            {
                CURRENCY = "aud";
            }
            else if (DropdownCurrency.SelectedIndex == 0)
            {
                CURRENCY = "usd";
            }
            else if (DropdownCurrency.SelectedIndex == 2)
            {
                CURRENCY = "jpy";
            }
        }

        private void CoinSearch_TextChanged(object sender, EventArgs e)
        {
            CoinSearch.CharacterCasing = CharacterCasing.Upper;
        }

        void GETINFOUSD(string CRYPTO, Label xUSDv, Label xBTCv, Label xUSDc, Label xUSD24c, Label xUSD7c, Label xUSDp, Label xUSD24p, Label xUSD7p)
        {
            API(@"https://api.coinmarketcap.com/v1/ticker/"+CRYPTO);

            CoinsDetailed = JsonConvert.DeserializeObject<List<MarketCap>>(jsonString);

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
                    if(data.symbol == "BTC"){ }
                    else { xBTCv.ForeColor = Color.Green; }
                }
                else if (Dchange < 0)
                {
                    if (data.symbol == "BTC") {}
                    else { xBTCv.ForeColor = Color.Red; }
                }
                else if (Dchange == 0)
                {
                    if (data.symbol == "BTC"){}
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
                        xUSDc.ForeColor = Color.Green;
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
                        xUSD24c.ForeColor = Color.Green;
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
                        xUSD7c.ForeColor = Color.Green;
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
                    percent_change_24h = percent_change_24h + " ▲";
                    xUSD24p.ForeColor = Color.Green;
                }
                else if (Dchange < 0)
                {
                    percent_change_24h = percent_change_24h + " ▼";
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
                    percent_change_7d = percent_change_7d + " ▲";
                    xUSD7p.ForeColor = Color.Green;
                }
                else if (Dchange < 0)
                {
                    percent_change_7d = percent_change_7d + " ▼";
                    xUSD7p.ForeColor = Color.Red;
                }
                else if (Dchange == 0)
                {
                    xUSD7p.ForeColor = Color.Yellow;
                }
                xUSD7p.Text = percent_change_7d;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Crypto UI = new Crypto();
            UI.Show();
        }
    }
}
