using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Data
{
    public class Price
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double PriceValue { get; set; }
    }
}
