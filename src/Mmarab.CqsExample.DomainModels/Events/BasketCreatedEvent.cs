using System;
using System.Collections.Generic;
using System.Text;

namespace Mmarab.CqsExample.DomainModels.Events
{
    public class BasketCreatedEvent : Event
    {
        public Guid id;

        public BasketCreatedEvent(Guid id)
        {
            this.id = id;
        }
    }
}
