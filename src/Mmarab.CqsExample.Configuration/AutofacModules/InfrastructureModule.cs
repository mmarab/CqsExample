using System.IO;
using Autofac;
using Microsoft.Extensions.Configuration;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.Infrastructure;

namespace Mmarab.CqsExample.Configuration.AutofacModules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IGenerateIdentifier>().As<GuidGenerator>();
            builder.Register(x => ConfigurationRootFactoryMethod()).SingleInstance();
        }

        private IConfigurationRoot ConfigurationRootFactoryMethod()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build();
        }
    }
}