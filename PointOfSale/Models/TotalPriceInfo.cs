using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class TotalPriceInfo : Link
    {
        public double TotalPrice { get; set; }
    }
}
