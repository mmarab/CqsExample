using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mmarab.CqsExample.Configuration.Tasks;

namespace Mmarab.CqsExample.Configuration
{
    public class Startup
    {
       public System.IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
            services.AddSwaggerGen();
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Mmarab.CqsExample.API")));       


            var builder = new ContainerBuilder();
            var modulesAssembly = Assembly.Load(new AssemblyName("Mmarab.CqsExample.Configuration"));
            builder.RegisterAssemblyModules(modulesAssembly);
            builder.Populate(services);
            var container = builder.Build();

            container.Resolve<IEnumerable<IStartUp>>().ToList().ForEach(x => x.Run());
           
            return container.Resolve<System.IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");         
            app.UseMvc();
            app.UseSwagger().UseSwaggerUi();
        }
    }
}
