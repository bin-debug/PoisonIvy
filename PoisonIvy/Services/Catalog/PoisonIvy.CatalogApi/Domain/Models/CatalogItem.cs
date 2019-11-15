using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.CatalogApi.Domain.Models
{
    public class CatalogItem
    {
        public string CatalogItemID { get; set; }
        public string CatalogItemName { get; set; }
        public decimal CatalogItemPrice { get; set; }
        public int Quantity { get; set; }
        public string Type { get { return "catalogItem"; } }
    }
}
