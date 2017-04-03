using Mmarab.CqsExample.DomainModels;
using Mmarab.CqsExample.DomainModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Mmarab.CqsExample.Models
{
    public class Basket : AggregateRoot
    {
        private List<Item> _items;

        public Guid _id;

        public Basket() { }

        public override Guid Id
        {
            get { return _id; }
        }

        public Basket(Guid id)
        {
           ApplyChange(new BasketCreatedEvent(id));
        }

        private void Apply(BasketCreatedEvent @event)
        {
            _items = new List<Item>();
            _id = @event.id;
        }

        public void AddItem(Item item)
        {
            ApplyChange(new BasketItemCreatedEvent(item));
        }

        private void Apply(BasketItemCreatedEvent @event)
        {
            _items.Add(@event.item);
        }

        public void DeleteItem(Guid itemId)
        {
           
            ApplyChange(new BasketItemDeletedEvent(itemId));
        }

        private void Apply(BasketItemDeletedEvent @event)
        {
            _items.RemoveAll(r => r.Id == @event.itemId);
        }

        public decimal GetTotal()
        {
            return _items.Sum(s => s.ItemPrice);
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
    }
}
