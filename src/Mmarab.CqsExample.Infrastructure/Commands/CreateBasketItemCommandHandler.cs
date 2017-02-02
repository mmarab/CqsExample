using System.Threading.Tasks;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.Application.Commands;
using Mmarab.CqsExample.Application.Commands.Contracts;
using Mmarab.CqsExample.Infrastructure.MockProductService;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Infrastructure.Commands
{
    public class CreateBasketItemCommandHandler : ICommandHandler<CreateBasketItem>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductDataService _productDataService;
        private readonly IGenerateIdentifier _generateIdentifier;

        public CreateBasketItemCommandHandler(IBasketRepository basketRepository, IProductDataService productDataService, IGenerateIdentifier generateIdentifier)
        {
            _basketRepository = basketRepository;
            _productDataService = productDataService;
            _generateIdentifier = generateIdentifier;
        }

        public async Task Handle(CreateBasketItem command)
        {
            var product = await _productDataService.Get(command.ProductId);
            var basket = await _basketRepository.Load(command.BasketId);
            basket.AddItem(new Item(_generateIdentifier.Generate(),product.Price, command.Quantity));
            await _basketRepository.Commit(basket);
        }
    }
}
