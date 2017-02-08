using Mmarab.CqsExample.Api.Models;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Application.Validation
{
    public interface IModelValidator
    {
    }

    public interface IModelValidator<TModel> : IModelValidator where TModel : class, new()
    {
        ValidationResult Validate(TModel model);
    }
}
