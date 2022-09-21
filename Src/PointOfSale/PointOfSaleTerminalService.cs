using PointOfSale.DataAccess.Interfaces;
using PointOfSale.Interfaces;
using System;
using System.Linq;

namespace PointOfSale
{
    public class PointOfSaleTerminalService : IPointOfSaleTerminalService
    {
        private readonly IPurchaseRepository  _purchaseRepository;
        private int _purchaseId;
        public PointOfSaleTerminalService() { }
        public PointOfSaleTerminalService(IPurchaseRepository purchaseRepository) : this()
        {
            _purchaseRepository = purchaseRepository;
        }

        public int StartShopping(int? purchaseId = null)
        {
            _purchaseId = purchaseId ?? _purchaseRepository.Add();
            return _purchaseId;
        }

        public void Scan(string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                throw new ArgumentNullException(nameof(productCode));
            }

            _purchaseRepository.AddProduct(_purchaseId, productCode);
        }

        public double CalculateTotal()
        {
            return _purchaseRepository.GetTotal(_purchaseId);
        }
    }
}
