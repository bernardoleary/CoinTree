using CoinTree.Logic;
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
        /// <summary>
        /// Get latest BTC price details.
        /// </summary>
        public async System.Threading.Tasks.Task<PriceDiff> GetAsync()
        {
            var priceHelper = new PriceHelper();
            var current = await priceHelper.GetPreviousPriceAsync();
            var previous = await priceHelper.GetPreviousPriceAsync();
            var priceDiff = priceHelper.GetPriceDiff(current, previous);            
            return priceDiff;
        }
    }
}
