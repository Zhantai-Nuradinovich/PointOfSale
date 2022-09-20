using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Interfaces
{
    public interface IPointOfSaleTerminalService
    {
        int StartShopping(int? purchaseId = null);
        void Scan(string productCode);
        double CalculateTotal();
    }
}
