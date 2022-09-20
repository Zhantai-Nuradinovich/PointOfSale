using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSale.Tests
{
    public class PointOfSaleTerminalTests
    {
        private readonly PointOfSaleTerminalService _terminal;
        private readonly IRepository _repository;
        public PointOfSaleTerminalTests()
        {
            _repository = new DefaultRepository();
            _terminal = new PointOfSaleTerminalService(_repository);
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

            double result = _terminal.CalculateTotal();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Scan_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _terminal.Scan(null));
        }
    }
}
