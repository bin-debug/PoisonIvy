using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.BasketApi.Domain.Commands
{
    public class CreateCatalogItemCommand : CatalogItemCommand
    {
        public CreateCatalogItemCommand(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Quantity = qty;
        }
    }
}
