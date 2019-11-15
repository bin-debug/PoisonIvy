using PoisonIvy.CatalogApi.Domain.Events;
using PoisonIvy.CatalogApi.Domain.Interfaces;
using PoisonIvy.CatalogApi.Domain.Models;
using PoisonIvy.Domain.Core.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoisonIvy.CatalogApi.Domain.EventHandlers
{
    public class CatalogItemEventHandler : IEventHandler<CatalogItemCreatedEvent>
    {
        private readonly IRepository<CatalogItem> _repository;

        public CatalogItemEventHandler(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }

        public Task Handle(CatalogItemCreatedEvent @event)
        {
            var obj = new CatalogItem()
            {
                CatalogItemName = @event.Name,
                CatalogItemPrice = @event.Price,
                Quantity = @event.Quantity
            };

            _repository.Upsert(obj);

            return Task.CompletedTask;
        }
    }
}
