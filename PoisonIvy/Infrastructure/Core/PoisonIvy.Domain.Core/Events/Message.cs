using System;
using System.Collections.Generic;
using System.Text;

namespace PoisonIvy.Domain.Core.Events
{

    // add a dependency to mediatR for IRequest<bool>
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message() => MessageType = GetType().Name;
    }
}
