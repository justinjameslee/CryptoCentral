using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAccessTEST01
{
    class MarketCap
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string rank { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        public string h_volume_usd { get; set; }
        public string market_cap_usd { get; set; }
        public string available_supply { get; set; }
        public string total_supply { get; set; }
        public string max_supply { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_7d { get; set; }
        public string last_updated { get; set; }
        public string price_aud { get; set; }
        public string h_volume_aud { get; set; }
        public string market_cap_aud { get; set; }
        public string price_jpy { get; set; }
        public string h_volume_jpy { get; set; }
        public string market_cap_jpy { get; set; }
        public string price_krw { get; set; }
        public string h_volume_krw { get; set; }
        public string market_cap_krw { get; set; }
    }
}
