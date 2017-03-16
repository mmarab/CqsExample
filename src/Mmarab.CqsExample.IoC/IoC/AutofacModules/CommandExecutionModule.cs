using Autofac;
using Mmarab.CqsExample.Application.Commands.Executor;
using Mmarab.CqsExample.IoC.IoC.Factories;
using System.Reflection;
using Module = Autofac.Module;

namespace Mmarab.CqsExample.IoC.IoC.AutofacModules
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
