using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace SKBeautyAPI.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy($"{configuration["Cors:PolicyName"]}",
                    builder => builder.WithOrigins($"{configuration["Cors:Origin"]}")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            //builder => builder.AllowAnyOrigin()
        }

        /// <summary>
        /// configure OpenAPI documentation for DevSupport
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "SK Beauty API",
                    Description = "API data",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Joshua Prior",
                        Email = "60011076@nrc.ac.uk"
                    },
                });
            });
        }

        public static void ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
        }

        //Used to debug authentication.
        private static Task AuthenticationFailed(AuthenticationFailedContext arg)
        {
            // For debugging purposes only!
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            arg.Response.ContentLength = s.Length;
            arg.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(s), 0, s.Length);
            return Task.FromResult(0);
        }

        private static Task AuthenticationChallenged(JwtBearerChallengeContext arg)
        {
            return Task.FromResult(0);
        }

        private static Task AuthenticationValidated(TokenValidatedContext arg)
        {
            return Task.FromResult(0);
        }
    }
}