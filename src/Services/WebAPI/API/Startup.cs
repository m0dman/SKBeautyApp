using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JsonNet.PrivateSettersContractResolvers;
using Newtonsoft.Json;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Data.Contexts;
using SKBeautyAPI.Extensions;
using Microsoft.Data.SqlClient;
using WebAPI.Application;

namespace SKBeautyAPI
{
    public class Startup
    {
        private readonly string _MyAllowSpecificOrigins;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _MyAllowSpecificOrigins = Configuration.GetValue<string>("Cors:PolicyName");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddControllers(config =>
                {
                    AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                }
            ).AddNewtonsoftJson(options =>
            {
                // Added to deal with private setters not being handled by Newtonsoft deserializer for controllers.
                options.SerializerSettings.ContractResolver = new PrivateSetterCamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            // The following line enables Application Insights telemetry collection.
            services.AddApplicationInsightsTelemetry();

            services.ConfigureSwaggerGen();
            services.ConfigureCors(Configuration);
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHealthChecks().AddDbContextCheck<SKBeautyContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SKBeautyContext dataContext, TelemetryConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });

#if DEBUG
                configuration.DisableTelemetry = true;
#endif
            }

            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_MyAllowSpecificOrigins);

            // Very important that this is before MVC (or anything that will require authentication)
            app.UseAuthentication();

            //Authorization needs to be between Routing and Endpoints.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // migrate any database changes on startup (includes initial db creation)
            try
            {
                dataContext.Database.Migrate();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"exception caught {e.Message} during SQL Migration");
            }
        }
    }
}
