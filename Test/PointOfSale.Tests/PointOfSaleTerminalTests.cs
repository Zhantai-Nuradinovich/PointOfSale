using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Interfaces;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSale.Tests
{
    public class PointOfSaleTerminalTests
    {
        private readonly PointOfSaleTerminalService _terminal;
        public PointOfSaleTerminalTests()
        {
            var productRepo = new ProductRepository();
            var purchaseRepo = new PurchaseRepository();
            _terminal = new PointOfSaleTerminalService(purchaseRepo, productRepo);

            var prices = GetDefaultPrices();
            _terminal.SetPricing(prices);
            _terminal.StartShopping();
        }

        [Theory]
        [InlineData(new string[] { "A", "B", "C", "D" }, 7.25)]
        [InlineData(new string[] { "A", "B", "C", "D", "A", "B", "A" }, 13.25)]
        [InlineData(new string[] { "C", "C", "C", "C", "C", "C", "C" }, 6)]
        public void CalculateTotal_InitialRequirements_ReturnsCorrectResult (string[] products, double expectedResult)
        {
            foreach (var product in products)
            {
                _terminal.Scan(product);
            }

            var result = _terminal.CalculateTotal();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateTotal_WithoutProducts_Returns0()
        {
            var result = _terminal.CalculateTotal();

            Assert.Equal(0, result);
        }

        [Fact]
        public void Scan_Null_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _terminal.Scan(null));
        }

        [Fact]
        public void SetPricing_Null_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _terminal.SetPricing(null));
        }

        private PriceInfo[] GetDefaultPrices()
        {
            return new PriceInfo[]
            {
                new PriceInfo(){ Amount = 1 , PriceValue = 0.75, ProductCode = "D" },
                new PriceInfo(){ Amount = 1 , PriceValue = 1, ProductCode = "C" },
                new PriceInfo(){ Amount = 1 , PriceValue = 1.25, ProductCode = "A" },
                new PriceInfo(){ Amount = 1 , PriceValue = 4.25, ProductCode = "B" },
                new PriceInfo(){ Amount = 3 , PriceValue = 3, ProductCode = "A" },
                new PriceInfo(){ Amount = 6 , PriceValue = 5, ProductCode = "C" }
            };
        }
    }
}
