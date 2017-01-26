using System.Reflection;
using Autofac;
using Mmarab.CqsExample.Application;
using Mmarab.CqsExample.Application.Queries;
using Mmarab.CqsExample.Configuration.Factories;
using Module = Autofac.Module;

namespace Mmarab.CqsExample.Configuration.AutofacModules
{
    public class QueryExecutionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QueryFactory>().As<IQueryFactory>();
            builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Mmarab.CqsExample.Infrastructure")))
               .AsClosedTypesOf(typeof(IQuery<,>));
        }
    }
}