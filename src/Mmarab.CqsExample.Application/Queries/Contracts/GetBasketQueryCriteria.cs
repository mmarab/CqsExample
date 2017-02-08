using System;

namespace Mmarab.CqsExample.Application.Queries.Contracts
{
    public class GetBasketQueryCriteria
    {
        public Guid Id { get; }

        public GetBasketQueryCriteria(Guid id)
        {
            Id = id;
        }
    }
}
