using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Queries.Executor
{
    public abstract class Query<TCriteria, TResult> : IQuery<TCriteria, TResult>
    {
        public async Task<TResult> Execute(TCriteria criteria)
        {
            return await DoExecute(criteria);
        }

        protected abstract Task<TResult> DoExecute(TCriteria criteria);
    }
}
