using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinTree.Models
{
    public class PriceDiff
    {
        [JsonProperty("previous")]
        public Price Previous { get; set; }
        [JsonProperty("current")]
        public Price Current { get; set; }
    }
}