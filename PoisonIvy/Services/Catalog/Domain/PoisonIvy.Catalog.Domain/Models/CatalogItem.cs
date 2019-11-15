using System;
using System.Collections.Generic;
using System.Text;

namespace PoisonIvy.Catalog.Domain.Models
{
    public class CatalogItem
    {
        public string CatalogItemID { get; set; }
        public string CatalogItemName { get; set; }
        public decimal CatalogItemPrice { get; set; }
        public int Quantity 
    }
}
