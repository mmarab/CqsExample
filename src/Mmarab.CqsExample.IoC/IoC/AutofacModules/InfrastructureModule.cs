using Autofac;
using Microsoft.Extensions.Configuration;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.DomainModels;
using Mmarab.CqsExample.Infrastructure;
using Mmarab.CqsExample.Infrastructure.MockProductService;
using Mmarab.CqsExample.Models;
using System.IO;

namespace Mmarab.CqsExample.IoC.IoC.AutofacModules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDataService>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<BasketRepository>().As<IBasketRepository>().SingleInstance();
            builder.RegisterType<EventStore>().As<IEventStore>().SingleInstance();
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