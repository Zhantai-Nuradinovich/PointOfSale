using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    /// <summary>
    /// Represents response with a link to the next logical method 
    /// </summary>
    public class ScanInfo : Link
    {
        public Link TotalPrice { get; set; }
    }
}
