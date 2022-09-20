using PointOfSale.DataAccess.Interfaces;
using PointOfSale.Interfaces;
using System;
using System.Linq;

namespace PointOfSale
{
    public class PointOfSaleTerminalService : IPointOfSaleTerminalService
    {
        private readonly IRepository  _repository;
        private int _purchaseId;
        public PointOfSaleTerminalService() { }
        public PointOfSaleTerminalService(IRepository repository) : this()
        {
            _repository = repository;
        }

        public int StartShopping(int? purchaseId = null)
        {
            _purchaseId = purchaseId ?? _repository.AddNewPurchase();
            return _purchaseId;
        }

        public void Scan(string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                throw new ArgumentNullException(nameof(productCode));
            }

            _repository.AddProductToPurchase(productCode, _purchaseId);
        }

        public double CalculateTotal()
        {
            var purchase = _repository.GetPurchaseById(_purchaseId);
            var prices = _repository.GetDefaultPrices();
            var selectedProductsGrouped = purchase.Products.GroupBy(x => x.Code)
                             .Select(x => (x.Key, x.Count()));

            double totalPrice = 0;
            foreach (var selectedProductAndCount in selectedProductsGrouped)
            {
                var selectedCount = selectedProductAndCount.Item2;
                var productPrices = prices.Where(x => x.Product.Code == selectedProductAndCount.Key
                                                   && x.Amount <= selectedCount)
                                          .OrderByDescending(x => x.Amount);

                foreach (var price in productPrices)
                {
                    totalPrice += (selectedCount / price.Amount) * price.PriceValue;
                    selectedCount -= price.Amount;
                }
            }

            purchase.TotalPrice = totalPrice;
            return totalPrice;
        }
    }
}
