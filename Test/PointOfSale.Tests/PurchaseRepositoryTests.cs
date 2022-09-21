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
            _purchaseRepository = new PurchaseRepository();
        }

        [Fact]
        public void GetAll_WithoudAddingNewPurchases_ReturnsEmptyList()
        {
            var purchases = _purchaseRepository.GetAll();

            Assert.Empty(purchases);
        }

        [Fact]
        public void AddPurchase_AddFirstPurchase_ReturnsPurchaseId()
        {
            var purchaseId = _purchaseRepository.Add();

            var singlePurchaseId = _purchaseRepository.GetAll().Single().Id;

            Assert.Equal(purchaseId, singlePurchaseId);
        }

        [Fact]
        public void GetByIdOrDefault_CorrectId_ReturnsPurchase()
        {
            var purchaseId = _purchaseRepository.Add();

            var purchase = _purchaseRepository.GetByIdOrDefault(purchaseId);

            Assert.NotNull(purchase);
        }

        [Fact]
        public void GetByIdOrDefault_IncorrectId_ReturnsNull()
        {
            var purchase = _purchaseRepository.GetByIdOrDefault(0);

            Assert.Null(purchase);
        }
        
        [Fact]
        public void AddProductToPurchase_AddDefaultProducts_Returns4ProductsInPurchase()
        {
            var productsCount = 4;
            var purchaseId = _purchaseRepository.Add();
            var products = new ProductRepository().GetAll();

            foreach (var product in products)
            {
                _purchaseRepository.AddProduct(purchaseId, product);
            }

            var purchase = _purchaseRepository.GetByIdOrDefault(purchaseId);
            Assert.Equal(productsCount, purchase.Products.Count);
        }

        [Fact]
        public void AddProductToPurchase_nullInput_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _purchaseRepository.AddProduct(0, null));
        }
    }
}
