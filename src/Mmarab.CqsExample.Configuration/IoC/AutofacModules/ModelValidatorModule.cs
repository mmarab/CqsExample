using System.Reflection;
using Mmarab.CqsExample.IoC.IoC.Factories;
using Module = Autofac.Module;
using Autofac;
using Mmarab.CqsExample.Application.Validation;

namespace Mmarab.CqsExample.IoC.IoC.AutofacModules
{
    public class ModelValidatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ModelValidatorFactory>().As<IModelValidatorFactory>();
            builder.RegisterType<ModelValidationExecutor>().As<IModelValidationExecutor>();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Mmarab.CqsExample.Application")))
               .AsClosedTypesOf(typeof(IModelValidator<>));
        }
    }
}