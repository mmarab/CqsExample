using Microsoft.AspNetCore.Mvc;
using Mmarab.CqsExample.Application.Queries;
using Mmarab.CqsExample.Application.Validation;

namespace Mmarab.CqsExample.Api
{
    public class BaseController : Controller
    {
        public IQueryExecutor Query { get; }
        public IModelValidationExecutor ModelValidation { get; }
        public BaseController(IQueryExecutor query, IModelValidationExecutor modelValidation)
        {
            Query = query;
            ModelValidation = modelValidation;
        }
    }
}
