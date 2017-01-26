using System.Collections.Generic;

namespace Mmarab.CqsExample.Application.Validation
{
    public interface IModelValidatorFactory
    {
        IEnumerable<IModelValidator<TModel>> Create<TModel>() where TModel : class, new();
        void Destroy<TModel>(IEnumerable<IModelValidator<TModel>> command) where TModel : class, new();
    }
}