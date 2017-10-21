using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinTree.Models
{
    public class Price
    {
        [JsonProperty("ask")]
        public string Ask { get; set; }
        [JsonProperty("bid")]
        public string Bid { get; set; }
        [JsonProperty("spot")]
        public string Spot { get; set; }
    }
}