using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PowerBI.Data.ReportingDB;
using PowerBI.Models.Configuration;
using PowerBI.Services;
using PowerBI.Services.Extensions;
using System.Collections.Generic;
using System.Text;

namespace PowerBI
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Authentication:Audience"],
                        ValidAudience = Configuration["Authentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtEncryptionKey"]))
                    };
                });

            services.AddControllers().AddControllersAsServices();

            services.AddSwaggerDocumentation();

            services.Configure<PowerBIConfig>(this.Configuration.GetSection("PowerBIConfig"));

            services.Configure<AuthenticationConfig>(this.Configuration.GetSection("Authentication"));

            services.AddDbContext<ReportingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Reporting")));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            

            app.Use((httpContext, next) => // For the oauth2-less!
            {
                if (httpContext.Request.Headers.ContainsKey("X-Authorization"))
                {
                    httpContext.Request.Headers.Add("Authorization", httpContext.Request.Headers["X-Authorization"]);
                }

                return next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwaggerDocumentation();
        }
    }
}
