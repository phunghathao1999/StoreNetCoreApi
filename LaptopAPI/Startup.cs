using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LaptopAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins(
                                "http://localhost:4000/"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4000/")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});


            services.AddDbContext<laptopContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("laptopContext")));
            services.AddAutoMapper(typeof(MappingProfile));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<ICartDetailRepository, CartDetailRepository>();
            services.AddScoped<ICartDetailService, CartDetailService>();

            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionService, PromotionService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
