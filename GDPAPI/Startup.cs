using Autofac;
using GDPAPI.UnitOfWork;
using GDPAPI.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GDPAPI
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

            services.AddDbContext<ApiContext>(x => x.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));
            services.AddControllers().AddControllersAsServices();
            services.AddCors(options => 
            {
                options.AddPolicy("GDPPolicy", builder => 
                {
                    builder
                        .WithOrigins("managemybus.azurewebsites.net", "front.gdp.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var containerBuilder = new ContainerBuilder();
            ConfigureContainer(containerBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("GDPPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // wire up using autofac specific APIs here

            containerBuilder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>();


        }
    }
}
