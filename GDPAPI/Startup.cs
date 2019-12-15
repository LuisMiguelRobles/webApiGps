using System.Text;
using Autofac;
using GDPAPI.UnitOfWork;
using GDPAPI.Persistence.Context;
using GDPAPI.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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
            var secretKey = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JWT:secretKey"));

            services.AddDbContext<ApiContext>(x => x.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                });

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
            containerBuilder.RegisterType<Utilities.Utilities>().As<IUtilities>();


        }
    }
}
