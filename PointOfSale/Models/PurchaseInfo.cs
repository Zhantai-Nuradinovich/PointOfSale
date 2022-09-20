using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class PurchaseInfo : Link
    {
        public int PurchaseId { get; set; }
        public Link Scan { get; set; }
    }
}
