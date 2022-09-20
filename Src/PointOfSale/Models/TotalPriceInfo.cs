using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    /// <summary>
    /// Represents response for total price of 1 purchase 
    /// </summary>
    public class TotalPriceInfo : Link
    {
        public double TotalPrice { get; set; }
    }
}
