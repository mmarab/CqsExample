﻿using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<in TCriteria, TResult> : IQuery
    {
        Task<TResult> Execute(TCriteria criteria);
    }

}
