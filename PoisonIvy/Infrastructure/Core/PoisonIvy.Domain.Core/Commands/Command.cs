using PoisonIvy.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoisonIvy.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
