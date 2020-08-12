using KalaGhar.Application.Common.Interfaces;
using KalaGhar.Infrastructure.Identity;
using KalaGhar.Infrastructure.Persistance;
using KalaGhar.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KalaGhar.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
                 services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString("DefaultConnection"),
                                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
