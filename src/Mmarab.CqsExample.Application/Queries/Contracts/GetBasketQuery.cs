using System;

namespace Mmarab.CqsExample.Application.Queries.Contracts
{
    public class GetBasketQuery
    {
        public Guid Id { get; }

        public GetBasketQuery(Guid id)
        {
            Id = id;
        }
    }
}
