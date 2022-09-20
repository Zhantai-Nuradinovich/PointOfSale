using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    /// <summary>
    /// Represents hypermedia links
    /// </summary>
    public class Link
    {
        public const string GetMethod = "GET";

        public const string PostMethod = "POST";

        public const string DeleteMethod = "DELETE";

        [JsonProperty(Order = -3)]
        public string Href { get; set; }

        [JsonProperty(Order = -2)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        public string RouteName { get; set; }

        public object RouteValues { get; set; }
    }
}
