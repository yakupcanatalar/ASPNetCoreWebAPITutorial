using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UdemyNLayerProject.API.Extentions;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;
using UdemyNLayerProject.Data.UnitOfWorks;
using UdemyNLayerProject.Service.Services;

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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(Startup));
            //Not Found DI oldu�u i�in burada eklemeliyiz.
            services.AddScoped<ProdcutNotFoundFilter>();
            //Ba�lant�y� burada ekledik.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString()
                    ,o=>o.MigrationsAssembly("UdemyNLayerProject.Data"));
            });
            //Unit of work patternini eklemek i�in.Bir servis olarak ekledik.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //T�m kontrollerda bu validasyon kullan�l�r hale geldi.
            // [ValidationFilter] yapmam�za gerke yok t�m endpointler i�in
            services.AddControllers( o=>
            {
                o.Filters.Add(new ValidationFilter());
            });
            
            //Validasyonlar� kendim kontrol edece�im anlam�na geliyor.Default false.
            services.Configure<ApiBehaviorOptions>(options =>
           {
               options.SuppressModelStateInvalidFilter = true;
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //Configure middlewareleri ekledi�imiz katmanlar� ekledi�imiz method.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler();//Custom yazd���m�z extention methodu burada ekledik.
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
