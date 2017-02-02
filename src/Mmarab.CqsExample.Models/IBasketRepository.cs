using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Models
{
    public interface IBasketRepository
    {
        Task Commit(Basket basket);
        Task<Basket> Load(Guid id);
    }
}
