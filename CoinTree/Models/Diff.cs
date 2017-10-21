using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinTree.Models
{
    public class Diff
    {
        [JsonProperty("percentagediffask")]
        public string PercentageDiffAsk { get; set; }
        [JsonProperty("percentagediffbid")]
        public string PercentageDiffBid { get; set; }
        [JsonProperty("percentagediffspot")]
        public string PercentageDiffSpot { get; set; }
    }
}