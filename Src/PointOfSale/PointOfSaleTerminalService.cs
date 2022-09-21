using PointOfSale.DataAccess.Interfaces;
using PointOfSale.Interfaces;
using PointOfSale.Models;
using PointOfSale.Utilities;
using System;
using System.Linq;

namespace PointOfSale
{
    public class PointOfSaleTerminalService : IPointOfSaleTerminalService
    {
        private readonly IPurchaseRepository  _purchaseRepository;

        private readonly IProductRepository  _productRepository;

        private int _purchaseId;

        private PriceInfo[] _prices;

        public PointOfSaleTerminalService() { }

        public PointOfSaleTerminalService(IPurchaseRepository purchaseRepository, IProductRepository productRepository) : this()
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }

        public int StartShopping(int? purchaseId = null)
        {
            _purchaseId = purchaseId ?? _purchaseRepository.Add();
            return _purchaseId;
        }

        public void Scan(string productCode)
        {
            var product = _productRepository.GetByCodeOrDefault(productCode);

            if (product == null)
            {
                throw new InvalidOperationException("Incorrect productCode");
            }

            _purchaseRepository.AddProduct(_purchaseId, product);
        }

        public double CalculateTotal()
        {
            var purchase = _purchaseRepository.GetByIdOrDefault(_purchaseId);
            var total = PriceHelper.CalculateTotal(_prices, purchase);
            return total;
        }

        public void SetPricing(PriceInfo[] prices)
        {
            if(prices == null)
            {
                throw new InvalidOperationException("Prices are empty");
            }

            _prices = prices;
        }
    }
}
