using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Models
{
    /// <summary>
    /// Represents price information
    /// </summary>
    public class PriceInfo
    {
        public string ProductCode { get; set; }

        public int Amount { get; set; }

        public double PriceValue { get; set; }
    }
}
