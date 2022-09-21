using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.DataAccess
{
    /// <summary>
    /// Mocked purchase repository 
    /// </summary>
    public class PurchaseRepository : IPurchaseRepository
    {
        private List<Purchase> _purchases;

        private readonly IProductRepository _productRepository;
        
        private readonly IPriceRepository _priceRepository;

        public PurchaseRepository(IProductRepository productRepository, IPriceRepository priceRepository)
        {
            _productRepository = productRepository;
            _priceRepository = priceRepository;
        }

        public List<Purchase> GetAll()
        {
            return _purchases ??= new List<Purchase>();
        }

        public Purchase GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Creates a default purchase with 0 products
        /// </summary>
        /// <returns>Purchase Id</returns>
        public int Add()
        {
            var purchases = GetAll();
            var maxId = purchases.Any() ? purchases.Max(x => x.Id) : 0;
            var purchase = new Purchase() { Id = maxId + 1, Products = new List<Product>() };

            purchases.Add(purchase);
            return purchase.Id;
        }

        public void AddProduct(int purchaseId, string productCode)
        {
            var purchase = GetById(purchaseId);
            var product = _productRepository.GetByCode(productCode);
            if (product == null || purchase == null)
            {
                throw new ArgumentException("Product code or PurchaseId was incorrect. Please try again");
            }

            purchase.Products.Add(product);
        }

        public double GetTotal(int purchaseId)
        {
            var purchase = GetById(purchaseId);
            var prices = _priceRepository.GetAll();
            var selectedProductsGrouped = purchase.Products.GroupBy(x => x.Code)
                             .Select(x => (x.Key, x.Count()));

            double totalPrice = 0;
            foreach (var selectedProductAndCount in selectedProductsGrouped)
            {
                var selectedCount = selectedProductAndCount.Item2;
                var productPrices = prices.Where(x => x.Product.Code == selectedProductAndCount.Key
                                                   && x.Amount <= selectedCount)
                                          .OrderByDescending(x => x.Amount);

                foreach (var price in productPrices)
                {
                    totalPrice += (selectedCount / price.Amount) * price.PriceValue;
                    selectedCount -= price.Amount;
                }
            }

            purchase.TotalPrice = totalPrice;
            return totalPrice;
        }
    }
}
