using System.Reflection;
using Mmarab.CqsExample.IoC.IoC.Factories;
using Module = Autofac.Module;
using Autofac;
using Mmarab.CqsExample.Application.Queries.Executor;

namespace Mmarab.CqsExample.IoC.IoC.AutofacModules
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