using Autofac;
using AutoFacWebApi2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacWebApi2
{
    public class Startup
    {
        //public ContainerBuilder containerBuilder { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //containerBuilder = new ContainerBuilder();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // Register your own things directly with Autofac, like:
        //    builder.RegisterModule(new IoCConfigurator());
        //    builder.RegisterModule(new IoCConfigurator2());
        //}
    }
}
