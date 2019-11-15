using PoisonIvy.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.BasketApi.Domain.Commands
{
    public abstract class CatalogItemCommand : Command
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
    }
}
