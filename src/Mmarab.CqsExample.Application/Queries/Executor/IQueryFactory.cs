namespace Mmarab.CqsExample.Application.Queries
{
    public interface IQueryFactory
    {
        IQuery<TCriteria, TResult> Create<TCriteria, TResult>();
        void Destroy<TCriteria, TResult>(IQuery<TCriteria, TResult> query); 
    }
}