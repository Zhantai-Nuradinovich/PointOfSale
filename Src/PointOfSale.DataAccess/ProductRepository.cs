using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.DataAccess
{
    /// <summary>
    /// Mocked repository for 4 type of Products: A, B, C, D
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public List<Product> GetAll()
        {
            return _products ??= new List<Product>()
            {
                new Product("A"),
                new Product("B"),
                new Product("C"),
                new Product("D")
            };
        }

        public Product GetByCode(string code)
        {
            return GetAll().FirstOrDefault(x => x.Code == code);
        }
    }
}
