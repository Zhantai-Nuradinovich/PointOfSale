using PointOfSale.Data;
using PointOfSale.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSale.Tests
{
    public class PointOfSaleTerminalTests
    {
        private readonly PointOfSaleTerminalService _terminal;
        private readonly DefaultRepository _repository;
        public PointOfSaleTerminalTests()
        {
            _repository = new DefaultRepository();
            _terminal = new PointOfSaleTerminalService(_repository);
            _terminal.StartShopping();
        }

        [Fact]
        public void CalculateTotal_ABCD_Returns7_25()
        {
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("C");
            _terminal.Scan("D");
            
            double result = _terminal.CalculateTotal();

            Assert.Equal(7.25, result);
        }

        [Fact]
        public void CalculateTotal_ABCDABA_Returns13_75()
        {
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("C");
            _terminal.Scan("D");
            _terminal.Scan("A");
            _terminal.Scan("B");
            _terminal.Scan("A");

            double result = _terminal.CalculateTotal();

            Assert.Equal(13.25, result);
        }

        [Fact]
        public void CalculateTotal_CCCCCCC_Returns6()
        {
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");
            _terminal.Scan("C");

            double result = _terminal.CalculateTotal();

            Assert.Equal(6, result);
        }

        [Fact]
        public void Scan_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _terminal.Scan(null));
        }
    }
}
