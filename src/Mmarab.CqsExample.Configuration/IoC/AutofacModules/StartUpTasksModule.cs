using System.Reflection;
using Autofac;
using Mmarab.CqsExample.Configuration.IoC.Tasks;
using Module = Autofac.Module;

namespace Mmarab.CqsExample.Configuration.IoC.AutofacModules
{
    public class StartUpTasksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Mmarab.CqsExample.Configuration")))
                .Where(t => typeof(IStartUp).IsAssignableFrom(t)).AsImplementedInterfaces();
        }
    }
}