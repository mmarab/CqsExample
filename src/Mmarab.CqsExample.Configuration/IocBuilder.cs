using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mmarab.CqsExample.IoC
{
    public static class IocFactory
    {
        public static System.IServiceProvider Create(IServiceCollection services)
        {
            var container = new ContainerBuilder();
            var modulesAssembly = Assembly.Load(new AssemblyName("Mmarab.CqsExample.Configuration"));
            container.RegisterAssemblyModules(modulesAssembly);
            container.Populate(services);
            return container.Build().Resolve<System.IServiceProvider>();
        }
    }
}
