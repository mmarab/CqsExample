using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Queries
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IQueryFactory _queryFactory;

        public QueryExecutor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public async Task<TResult> Execute<TCriteria, TResult>(TCriteria criteria)
        {
            var query = _queryFactory.Create<TCriteria, TResult>();
            try
            {
                return await  query.Execute(criteria);
            }
            finally
            {
                _queryFactory.Destroy(query);
            }    
        }
    }
}
