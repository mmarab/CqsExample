using System;

namespace Mmarab.CqsExample.Application.Commands.Contracts
{
    public class DeleteBasketItem
    {
        public Guid BasketId { get; }
        public Guid ItemId { get; }

        public DeleteBasketItem(Guid basketId, Guid itemId )
        {
            BasketId = basketId;
            ItemId = itemId;
        }
    }
}
