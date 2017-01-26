using System.Linq;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Application.Validation
{
    public class ModelValidationExecutor : IModelValidationExecutor
    {
        private readonly IModelValidatorFactory _modelValidatorFactory;

        public ModelValidationExecutor(IModelValidatorFactory modelValidatorFactory)
        {
            _modelValidatorFactory = modelValidatorFactory;
        }

        public ValidationResult Validate<TModel>(TModel model) where TModel : class, new()
        {
            var modelValidators = _modelValidatorFactory.Create<TModel>().ToArray();
            if (!modelValidators.Any())
            {
                return ValidationResult.Ok;
            }

            try
            {
                return modelValidators.Single().Validate(model ?? new TModel());
            }
            finally
            {
                _modelValidatorFactory.Destroy(modelValidators);
            }
        }
    }
}
