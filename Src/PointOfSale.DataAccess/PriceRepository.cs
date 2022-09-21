using PointOfSale.DataAccess.Interfaces;
using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.DataAccess
{
    /// <summary>
    /// Mocked price repository
    /// </summary>
    public class PriceRepository : IPriceRepository
    {
        private List<Price> _prices;

        private readonly IProductRepository _productRepository;

        public PriceRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Price> GetAll()
        {
            return _prices ??= new List<Price>()
            {
                new Price(){ Amount = 1 , PriceValue = 0.75, Product = _productRepository.GetByCode("D") },
                new Price(){ Amount = 1 , PriceValue = 1, Product = _productRepository.GetByCode("C") },
                new Price(){ Amount = 1 , PriceValue = 1.25, Product = _productRepository.GetByCode("A") },
                new Price(){ Amount = 1 , PriceValue = 4.25, Product = _productRepository.GetByCode("B") },
                new Price(){ Amount = 3 , PriceValue = 3, Product = _productRepository.GetByCode("A") },
                new Price(){ Amount = 6 , PriceValue = 5, Product = _productRepository.GetByCode("C") }
            };
        }
    }
}
