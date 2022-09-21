using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSale.DataAccess
{
    /// <summary>
    /// Mocked repository with default 4 type of Products: A, B, C, D
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

        public Product GetByCodeOrDefault(string code)
        {
            return GetAll().FirstOrDefault(x => x.Code == code);
        }

        public void Add(string code)
        {
            var isExists = GetByCodeOrDefault(code) != null;
            if (isExists)
            {
                throw new InvalidOperationException($"Product with the code:{code} is already exists");
            }

            GetAll().Add(new Product(code));
        }
    }
}
