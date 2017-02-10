using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Queries
{
    public interface IQueryExecutor
    {
       Task<TResult> Execute<TCriteria, TResult>(TCriteria criteria);
    }
}
