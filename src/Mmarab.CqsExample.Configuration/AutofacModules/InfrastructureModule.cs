using System.IO;
using Autofac;
using Microsoft.Extensions.Configuration;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.Infrastructure;
using Mmarab.CqsExample.Models;

namespace Mmarab.CqsExample.Configuration.AutofacModules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryBasketRepository>().As<IBasketRepository>();
            builder.RegisterType<GuidGenerator>().As<IGenerateIdentifier>();
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