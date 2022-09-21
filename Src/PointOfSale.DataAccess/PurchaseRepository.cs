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

        public List<Purchase> GetAll()
        {
            return _purchases ??= new List<Purchase>();
        }

        public Purchase GetByIdOrDefault(int id)
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

        public void AddProduct(int purchaseId, Product product)
        {
            var purchase = GetByIdOrDefault(purchaseId);
            if (product == null || purchase == null)
            {
                throw new InvalidOperationException("Product code or PurchaseId was incorrect. Please try again");
            }

            purchase.Products.Add(product);
        }
    }
}
