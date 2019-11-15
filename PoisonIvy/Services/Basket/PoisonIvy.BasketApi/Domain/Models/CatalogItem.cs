using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.BasketApi.Domain.Models
{
    public class CatalogItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
