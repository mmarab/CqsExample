using System.Threading.Tasks;

namespace Mmarab.CqsExample.DomainModels
{ 

    public interface IProductRepository
    {
        Task<Product> Get(int id);
    }
}
