using Autofac;
using Mmarab.CqsExample.Application.Validation;
using System.Collections.Generic;

namespace Mmarab.CqsExample.IoC.IoC.Factories
{
    public class ModelValidatorFactory : IModelValidatorFactory
    {
        private readonly IComponentContext _context;

        public ModelValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public IEnumerable<IModelValidator<TModel>> Create<TModel>() where TModel : class, new()
        {
            return _context.Resolve<IEnumerable<IModelValidator<TModel>>>();
        }

        public void Destroy<TModel>(IEnumerable<IModelValidator<TModel>> command) where TModel : class, new()
        {
            
        }
    }
}