using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Infrastructure.Data.Contexts;
using WebAPI.Application.Common.Interfaces;
using WebAPI.Infrastructure.Contexts;

namespace WebAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SKBeautyContext>(options =>
                options.UseSqlServer(configuration.GetValue<string>("ConnectionSettings:DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<SKBeautyContext>());

            services.AddTransient<IDbContextFactory, DBContextFactory>();

            return services;
        }
    }
}
