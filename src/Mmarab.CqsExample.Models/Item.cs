using System;

namespace Mmarab.CqsExample.Models
{
    public class Item
    {
        public int Quantity { get; }
        public Guid Id { get;  }
        public decimal ItemPrice { get; }

        public Item(Guid id, decimal itemPrice, int quantity)
        {
            Quantity = quantity;
            Id = id;
            ItemPrice = itemPrice;
        }
    }
}