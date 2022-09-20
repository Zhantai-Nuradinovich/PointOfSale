using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.DataAccess
{/// <summary>
 /// Mocked repositories
 /// </summary>
    public class DefaultRepository : IRepository
    {
        private List<Product> _products;
        private List<Price> _prices;
        private List<Purchase> _purchases;

        public void AddProductToPurchase(string productCode, int purchaseId)
        {
            var purchase = GetPurchaseById(purchaseId);
            var product = GetProductByCode(productCode);
            if (product == null || purchase == null)
            {
                throw new ArgumentException("Product code or PurchaseId was incorrect. Please try again");
            }

            purchase.Products.Add(product);
        }
        public int AddNewPurchase()
        {
            var purchases = GetPurchases();
            var maxId = purchases.Any() ? purchases.Max(x => x.Id) : 1;
            var purchase = new Purchase() { Id = maxId + 1, Products = new List<Product>() };

            purchases.Add(purchase);
            return purchase.Id;
        }
        public Purchase GetPurchaseById(int id)
        {
            return GetPurchases().FirstOrDefault(x => x.Id == id);
        }
        public Product GetProductByCode(string code)
        {
            return GetProducts().FirstOrDefault(x => x.Code == code);
        }
        public List<Purchase> GetPurchases()
        {
            return _purchases ??= new List<Purchase>();
        }
        public List<Price> GetDefaultPrices()
        {
            return _prices ??= new List<Price>()
            {
                new Price(){ Amount = 1 , PriceValue = 0.75, Product = GetProductByCode("D") },
                new Price(){ Amount = 1 , PriceValue = 1, Product = GetProductByCode("C") },
                new Price(){ Amount = 1 , PriceValue = 1.25, Product = GetProductByCode("A") },
                new Price(){ Amount = 1 , PriceValue = 4.25, Product = GetProductByCode("B") },
                new Price(){ Amount = 3 , PriceValue = 3, Product = GetProductByCode("A") },
                new Price(){ Amount = 6 , PriceValue = 5, Product = GetProductByCode("C") }
            };
        }
        public List<Product> GetProducts()
        {
            return _products ??= new List<Product>()
            {
                new Product("A"),
                new Product("B"),
                new Product("C"),
                new Product("D")
            };
        }
    }
}
