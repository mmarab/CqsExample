using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Contracts
{
    public class CreateBasketCriteria
    {
        public Guid Id { get; }
    
        public CreateBasketCriteria(Guid id)
        {
            Id = id;
        }
    }
}
