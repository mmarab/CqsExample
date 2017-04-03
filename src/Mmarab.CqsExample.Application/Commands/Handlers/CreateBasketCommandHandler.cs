using System.Threading.Tasks;
using Mmarab.CqsExample.Application.Commands.Contracts;
using Mmarab.CqsExample.Application.Commands.Executor;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Application.Commands.Handlers
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task Handle(CreateBasketCommand command)
        {
            var basket = new Basket(command.Id);
            await _basketRepository.Commit(basket, null);
        }
    }
}
