using CoinTree.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;

namespace CoinTree.Controllers
{
    public class PriceController : ApiController
    {
        // This is only used when the application starts
        public async System.Threading.Tasks.Task<Price> GetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://api.cointree.com.au/v1/price/btc/aud");
                var price = JsonConvert.DeserializeObject<Price>(json);
                return price;
            }
        }
    }
}
