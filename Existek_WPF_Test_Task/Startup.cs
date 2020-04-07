using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DAL_Test_Task.Entities;
using BLL_Test_Task.Abstract;
using BLL_Test_Task.Services;
using Existek_WPF_Test_Task.AutoMapperProfiles;

namespace Existek_WPF_Test_Task
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup), typeof(CustomerProfile));
            services.AddDbContext<ClientContext>(ServiceLifetime.Scoped);
            services.AddScoped(typeof(ICountryService), typeof(CountryService));
            services.AddScoped(typeof(IPersonService), typeof(PersonService));
            services.AddScoped(typeof(IGreetingService), typeof(GreetingService));
            services.AddScoped(typeof(IPersonContactService), typeof(PersonContactService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        

    }
}
