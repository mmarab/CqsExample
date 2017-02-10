using Autofac;
using Mmarab.CqsExample.Application.Queries.Executor;

namespace Mmarab.CqsExample.IoC.IoC.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IComponentContext _context;

        public QueryFactory(IComponentContext context)
        {
            _context = context;
        }

        public IQuery<TCriteria, TResult> Create<TCriteria, TResult>()
        {
            return _context.Resolve<IQuery<TCriteria,TResult>> ();
        }

        public void Destroy<TCriteria, TResult>(IQuery<TCriteria, TResult> query)
        {
        }
    }
}