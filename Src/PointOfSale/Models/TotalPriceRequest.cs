using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Models
{
    public class TotalPriceRequest
    {
        public int PurchaseId { get; set; }
        public PriceInfo[] Prices { get; set; }
    }
}
