using System.Threading.Tasks;
using Mmarab.CqsExample.Application.Queries;
using Mmarab.CqsExample.Application.Queries.Contracts;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Infrastructure.Queries
{
    public class GetBasketQueryHandler : Query<GetBasketQuery, Basket>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        protected override async Task<Basket> DoExecute(GetBasketQuery criteria)
        {
           return await _basketRepository.Load(criteria.Id);
        }
    }
}
