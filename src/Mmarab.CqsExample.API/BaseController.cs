using Microsoft.AspNetCore.Mvc;
using Mmarab.CqsExample.Application.Commands.Executor;
using Mmarab.CqsExample.Application.Queries.Executor;
using Mmarab.CqsExample.Application.Validation;

namespace Mmarab.CqsExample.Api
{
    public class BaseController : Controller
    {
        public ICommandExecutor Command { get; }
        public IQueryExecutor Query { get; }
        public IModelValidationExecutor ModelValidation { get; }
        public BaseController(IQueryExecutor query, ICommandExecutor command, IModelValidationExecutor modelValidation)
        {
            Command = command;
            Query = query;
            ModelValidation = modelValidation;
        }
    }
}
