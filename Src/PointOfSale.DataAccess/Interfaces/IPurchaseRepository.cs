using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.DataAccess.Interfaces
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Purchase GetByIdOrDefault(int id);
        int Add();
        void AddProduct(int purchaseId, Product product);
    }
}
