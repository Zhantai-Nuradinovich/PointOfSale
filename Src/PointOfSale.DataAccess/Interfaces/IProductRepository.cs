using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByCodeOrDefault(string code);
    }
}
