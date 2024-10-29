using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using SalesService.Infrastructure.Context;

namespace SalesService.Infrastructure.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<Context.Context>(opt =>
        {
            opt.UseSqlServer(DbContextFactory.GetConnectionString(DbContextFactory.GetConfiguration()));
#if DEBUG
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();      
#endif
        });
        return services;
    }
    
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services)
    {
        return services;
    }
}