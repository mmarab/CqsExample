using System;
using System.Linq;
using Mmarab.CqsExample.Models;
using Xunit;

namespace Mmarab.CqsExample.UnitTests
{
    public class BasketTests
    {
        [Fact]
        public void CreateBasket_Basket_BasketCreated()
        {
            var guid = Guid.NewGuid();
            var basket = new Basket(guid);

            Assert.Equal(guid, basket.Id);
        }

        [Fact]
        public void AddBasketItem_Basket_BasketItemAdded()
        {
            var basket = new Basket(Guid.NewGuid());
            var item = new Item(Guid.NewGuid(), 12.99m,1);
            basket.AddItem(item);

            Assert.Equal(1, basket.GetItems().Count());
        }

        [Fact]
        public void RemoveBasketItem_Basket_BasketItemRemoved()
        {
            var itemId = Guid.NewGuid();
            var basket = new Basket(Guid.NewGuid());
            basket.AddItem(new Item(itemId, 12.99m,1));
            basket.DeleteItem(itemId);

            Assert.Equal(0, basket.GetItems().Count());
        }

        [Fact]
        public void GetTotal_Basket_BasketTotalShouldBeCorrect()
        {
            var itemId = Guid.NewGuid();
            var basket = new Basket(Guid.NewGuid());
            basket.AddItem(new Item(itemId, 12.99m,1));
            
            Assert.Equal(12.99m, basket.GetTotal());
        }


    }
}
