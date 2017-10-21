using CoinTree.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CoinTree.Logic
{
    public class PriceHelper
    {
        private const string priceFile = @"~/price.json";

        public async Task<Price> GetCoinTreePriceAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://api.cointree.com.au/v1/price/btc/aud");
                var price = JsonConvert.DeserializeObject<Price>(json);             
                return price;
            }
        }

        public async Task<Price> GetPreviousPriceAsync()
        {
            try
            {
                using (var reader = new StreamReader(HttpContext.Current.Server.MapPath(priceFile)))
                {
                    var price = JsonConvert.DeserializeObject<Price>(reader.ReadToEnd());
                    return price;
                }
            }
            catch
            {
                // If we have no record of the previous price, make it the current price
                var price = await GetCoinTreePriceAsync();
                SetPreviousPrice(price);
                return price;
            }
        }

        public PriceDiff GetPriceDiff(Price current, Price previous)
        {
            var priceDiff = new PriceDiff();
            priceDiff.Current = current;
            priceDiff.Previous = previous;
            priceDiff.PercentageDiff = new Diff
            {
                PercentageDiffAsk = GetPrecentageChange(current.Ask, previous.Ask),
                PercentageDiffBid = GetPrecentageChange(current.Bid, previous.Bid),
                PercentageDiffSpot = GetPrecentageChange(current.Spot, previous.Spot)
            };
            return priceDiff;
        }

        private string GetPrecentageChange(string priceCurrent, string pricePrevious)
        {
            var percentage = Convert.ToDouble(priceCurrent) / Convert.ToDouble(pricePrevious);
            var diff = 1 - percentage;
            return string.Format("{0:0.00}", diff*100);
        }

        private void SetPreviousPrice(Price current)
        {
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath(priceFile), false))
            {
                writer.WriteLine(JsonConvert.SerializeObject(current));
            }
        }
    }
}