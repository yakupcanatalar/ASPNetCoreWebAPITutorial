using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.UnitOfWorks;

namespace UdemyNLayerProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices Servislerimizi ekledi�imiz method
        public void ConfigureServices(IServiceCollection services)
        {
            //Ba�lant�y� burada ekledik.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()
                    ,o=>o.MigrationsAssembly("UdemyNLayerProject.Data"));
            });
            //Unit of work patternini eklemek i�in.Bir servis olarak ekledik.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //Configure middlewareleri ekledi�imiz katmanlar� ekledi�imiz method.
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
