using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmarab.CqsExample.Application.Commands;
using Mmarab.CqsExample.Application.Commands.Contracts;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Infrastructure.Commands
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCriteria>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task Handle(CreateBasketCriteria command)
        {
            var basket = new Basket(command.Id);
            await _basketRepository.Commit(basket);
        }
    }
}
