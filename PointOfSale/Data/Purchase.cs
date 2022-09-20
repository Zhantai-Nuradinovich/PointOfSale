using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
