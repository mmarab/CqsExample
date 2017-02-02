using System.Collections.Generic;
using System.Threading.Tasks;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Infrastructure
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        private List<Basket> _baskets;

        public InMemoryBasketRepository()
        {
            _baskets = new List<Basket>();
        } 
        public async Task Commit(Basket basket)
        {
           await Task.Run(()=>_baskets.Add(basket));
        }
    }
}
