using System;
using Mmarab.CqsExample.DomainModels;
using Mmarab.CqsExample.Models;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private IEventStore _eventStore;

        public BasketRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public async Task Commit(Basket basket, int? expectedVersion)
        {
           await _eventStore.SaveEvents(basket.Id, basket.GetUncommittedChanges(), expectedVersion);
        }

        public async Task<Basket> Load(Guid id)
        {
            var obj = new Basket();//lots of ways to do this
            var e = await _eventStore.GetEventsForAggregate(id);
            obj.LoadsFromHistory(e);
            return obj;
        }
    }
}
