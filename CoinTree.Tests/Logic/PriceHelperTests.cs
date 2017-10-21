using CoinTree.Logic;
using CoinTree.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTree.Tests.Logic
{
    [TestFixture]
    class PriceHelperTests
    {
        [TestCase("12.04", "12.04", ExpectedResult = "0.00")]
        [TestCase("12.04", "12.00", ExpectedResult = "0.33")]
        [TestCase("12.04", "25.00", ExpectedResult = "-51.84")]
        [TestCase("1000.04", "25.00", ExpectedResult = "3900.16")]
        public string GetPriceDiffTest(string current, string previous)
        {
            // Arrange
            var priceCurrent = new Price { Ask = current, Bid = current, Spot = current };
            var pricePrevious = new Price { Ask = previous, Bid = previous, Spot = previous };
            var priceHelper = new PriceHelper();

            // Act
            var priceDiff = priceHelper.GetPriceDiff(priceCurrent, pricePrevious);

            // Assert
            return priceDiff.PercentageDiff.PercentageDiffAsk;
        }
    }
}
