using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Contracts
{
    public class UpdateBasketItem
    {
        public Guid BasketId { get; }
        public Guid ItemId { get; }
        public int Quantity { get; }
    
        public UpdateBasketItem(Guid basketId, Guid itemId, int quantity)
        {
            BasketId = basketId;
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}
