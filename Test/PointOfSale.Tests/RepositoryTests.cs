using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PointOfSale.Tests
{
    public class RepositoryTests
    {
        private readonly IRepository _repository;
        public RepositoryTests()
        {
            _repository = new DefaultRepository();
        }

        [Fact]
        public void AddNewPurchase_AddFirstPurchase_Returns1()
        {
            var purchaseId = _repository.AddNewPurchase();

            var singlePurchaseId = _repository.GetPurchases().Single().Id;

            Assert.Equal(purchaseId, singlePurchaseId);
        }

        [Fact]
        public void AddProductToPurchase_nullInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _repository.AddProductToPurchase(null, 0));
        }
    }
}
