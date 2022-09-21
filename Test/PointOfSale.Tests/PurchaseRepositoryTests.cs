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
    public class PurchaseRepositoryTests
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseRepositoryTests()
        {
            var productRepo = new ProductRepository();
            var priceRepo = new PriceRepository(productRepo);
            _purchaseRepository = new PurchaseRepository(productRepo, priceRepo);
        }

        [Fact]
        public void AddNewPurchase_AddFirstPurchase_Returns1()
        {
            var purchaseId = _purchaseRepository.Add();

            var singlePurchaseId = _purchaseRepository.GetAll().Single().Id;

            Assert.Equal(purchaseId, singlePurchaseId);
        }

        [Fact]
        public void AddProductToPurchase_nullInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _purchaseRepository.AddProduct(0, null));
        }
    }
}
