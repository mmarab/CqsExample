using System.Threading.Tasks;

namespace Mmarab.CqsExample.Infrastructure.MockProductService
{
    public interface IProductDataService
    {
        Task<Product> Get(int id);
    }
}
