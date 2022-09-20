using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.DataAccess.Interfaces
{
    public interface IRepository
    {
        List<Product> GetProducts();
        List<Price> GetDefaultPrices();
        List<Purchase> GetPurchases();
        Product GetProductByCode(string code);
        Purchase GetPurchaseById(int id);
        int AddNewPurchase();
        void AddProductToPurchase(string productCode, int purchaseId);
    }
}
