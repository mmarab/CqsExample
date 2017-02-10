using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mmarab.CqsExample.IoC;

namespace Mmarab.CqsExample.Api
{
    public class Startup
    {
        public System.IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
            services.AddSwaggerGen();
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Mmarab.CqsExample.API")));
            return IocFactory.Create(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseCors("AllowAll");
            app.UseMvc();
            app.UseSwagger().UseSwaggerUi();
        }
    }
}
