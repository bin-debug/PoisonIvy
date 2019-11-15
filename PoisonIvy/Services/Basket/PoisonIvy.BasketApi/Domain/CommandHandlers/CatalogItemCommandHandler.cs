using MediatR;
using PoisonIvy.BasketApi.Domain.Commands;
using PoisonIvy.BasketApi.Domain.Events;
using PoisonIvy.Domain.Core.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PoisonIvy.BasketApi.Domain.CommandHandlers
{
    public class CatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, bool>
    {
        private readonly IEventBus _bus;

        public CatalogItemCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new CatalogItemCreatedEvent(request.Name, request.Price, request.Quantity));
            return Task.FromResult(true);
        }
    }
}
