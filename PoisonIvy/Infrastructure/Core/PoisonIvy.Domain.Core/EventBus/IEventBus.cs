using PoisonIvy.Domain.Core.Commands;
using PoisonIvy.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoisonIvy.Domain.Core.EventBus
{
    public interface IEventBus
    {
        Task Send<T>(T Command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>() 
            where T : Event 
            where TH : IEventHandler;
    }
}
