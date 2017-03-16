using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Models
{
    public class Basket
    {
        private readonly List<Item> _items; 
        public Guid Id { get; }

        public Basket(Guid id)
        {
            _items = new List<Item>();
            Id = id;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void DeleteItem(Guid itemId)
        {
            _items.RemoveAll(r => r.Id == itemId);
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
