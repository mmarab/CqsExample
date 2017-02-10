﻿namespace Mmarab.CqsExample.Application.Queries.Executor
{
    public interface IQueryFactory
    {
        IQuery<TCriteria, TResult> Create<TCriteria, TResult>();
        void Destroy<TCriteria, TResult>(IQuery<TCriteria, TResult> query); 
    }
}