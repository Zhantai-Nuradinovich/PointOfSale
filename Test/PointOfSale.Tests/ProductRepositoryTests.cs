using PointOfSale.DataAccess;
using PointOfSale.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PointOfSale.Tests
{
    public class ProductRepositoryTests
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        [Fact]
        public void GetAllProducts_ReturnsDefault4Products()
        {
            var productsCount = 4;

            var products = _productRepository.GetAll();

            Assert.Equal(productsCount, products.Count);
        }


        [Fact]
        public void GetByCodeOrDefault_CorrectCode_ReturnsProduct()
        {
            var product = _productRepository.GetByCodeOrDefault("A");

            Assert.NotNull(product);
        }

        [Fact]
        public void GetByCodeOrDefault_IncorrectCode_ReturnsNull()
        {
            var product = _productRepository.GetByCodeOrDefault("QWERTY");

            Assert.Null(product);
        }
    }
}
