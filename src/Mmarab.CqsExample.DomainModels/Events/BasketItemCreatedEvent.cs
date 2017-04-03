using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.DomainModels.Events
{
    public class BasketItemCreatedEvent : Event
    {
        public Item item;

        public BasketItemCreatedEvent(Item item)
        {
            this.item = item;
        }
    }
}
