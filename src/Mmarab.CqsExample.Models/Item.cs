using System;

namespace Mmarab.CqsExample.Models
{
    public class Item
    {
        public Guid Id { get;  }
        public decimal ItemPrice { get; }

        public Item(Guid id, decimal itemPrice)
        {
            Id = id;
            ItemPrice = itemPrice;
        }
    }
}