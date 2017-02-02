using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Contracts
{
    public class CreateBasketCommand
    {
        public Guid Id { get; }
    
        public CreateBasketCommand(Guid id)
        {
            Id = id;
        }
    }
}
