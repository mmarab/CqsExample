using System;
using System.Collections.Generic;
using System.Linq;
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
            //We dont really care, if it exists just delete it and then add it again. 
           _baskets.RemoveAll(r => r.Id == basket.Id);
           
            await Task.Run(()=>_baskets.Add(basket));
        }

        public async Task<Basket> Load(Guid id)
        {
           return await Task.Run(() => _baskets.First(f => f.Id == id));
        }
    }
}
