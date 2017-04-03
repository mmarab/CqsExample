using System;

namespace Mmarab.CqsExample.DomainModels.Events
{
    public class BasketItemDeletedEvent : Event
    {
        public Guid itemId;

        public BasketItemDeletedEvent(Guid itemId)
        {
            this.itemId = itemId;
        }
    }
}
