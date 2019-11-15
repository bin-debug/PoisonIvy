using PoisonIvy.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.CatalogApi.Domain.Events
{
    public class CatalogItemCreatedEvent : Event
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public CatalogItemCreatedEvent(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Quantity = qty;
        }
    }
}
