using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataAccess.Models
{
    public class Product
    {
        public string Code { get; set; }

        public Product() { }

        public Product(string code) : this()
        {
            Code = code;
        }

    }
}
