using Microsoft.Extensions.DependencyInjection;
using PoisonIvy.Domain.Core.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PoisonIvy.RabbitMQ;

namespace PoisonIvy.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
        }
    }
}
