using CoinTree.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;

namespace CoinTree.Controllers
{
    public class PriceController : ApiController
    {
        // This is only used when the application starts
        public async System.Threading.Tasks.Task<PriceDiff> GetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://api.cointree.com.au/v1/price/btc/aud");                
                var currentPrice = JsonConvert.DeserializeObject<Price>(json);
                var priceDiff = new PriceDiff { Current = currentPrice };
                try
                {
                    using (var reader = new StreamReader(HttpContext.Current.Server.MapPath(@"~/price.json")))
                    {
                        priceDiff.Previous = JsonConvert.DeserializeObject<Price>(reader.ReadToEnd());
                    }
                }
                catch
                {
                    // If we have no record of the previous price, make it the current price
                    priceDiff.Previous = currentPrice;
                }
                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath(@"~/price.json"), false))
                {
                    writer.WriteLine(json);
                }
                return priceDiff;
            }
        }
    }
}
