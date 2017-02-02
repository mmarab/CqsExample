using System.Reflection;
using Autofac;
using Mmarab.CqsExample.Application.Commands;
using Mmarab.CqsExample.Configuration.Factories;
using Mmarab.CqsExample.Infrastructure;
using Mmarab.CqsExample.Models;
using Module = Autofac.Module;

namespace Mmarab.CqsExample.Configuration.AutofacModules
{
    public class CommandExecutionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandExecutor>().As<ICommandExecutor>();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Mmarab.CqsExample.Infrastructure")))
               .AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();
        }
    }
}
