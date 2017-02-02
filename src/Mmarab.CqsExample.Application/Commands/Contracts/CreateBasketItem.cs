using System;

namespace Mmarab.CqsExample.Application.Commands.Contracts
{
    public class CreateBasketItem
    {
        public Guid BasketId;
        public int ProductId;
        public  int Quantity;

        public CreateBasketItem(Guid basketId, int productId, int quantity)
        {
            BasketId = basketId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
