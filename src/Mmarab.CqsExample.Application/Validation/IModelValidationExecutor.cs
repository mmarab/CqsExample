using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Application.Validation
{
    public interface IModelValidationExecutor
    {
       ValidationResult Validate<TModel>(TModel model) where TModel : class, new();
    }
}
