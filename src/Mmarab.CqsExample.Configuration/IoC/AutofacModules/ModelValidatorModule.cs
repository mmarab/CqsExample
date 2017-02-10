using System.Reflection;
using Autofac;
using Mmarab.CqsExample.Application.Validation;
using Mmarab.CqsExample.Configuration.IoC.Factories;
using Module = Autofac.Module;

namespace Mmarab.CqsExample.Configuration.IoC.AutofacModules
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