using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Infrastructure.MockProductService
{
    public class ProductDataService : IProductRepository
    {
        private readonly List<Product> _mockList = new List<Product> {
            new Product("Shirt", 12.99m, 1),
            new Product("Jumper", 20.89m, 2),
            new Product("Trousers", 15.00m, 3),
            new Product("Belt", 8.99m, 4),
            new Product("Coat", 49.50m, 5)}; 

        public async Task<Product> Get(int id)
        {
            return await Task.Run(() => _mockList.First(f => f.Id == id));
        }
    }
}