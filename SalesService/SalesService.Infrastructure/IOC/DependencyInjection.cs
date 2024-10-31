using Microsoft.Extensions.DependencyInjection;
using SalesService.Domain.Interfaces.Repository;
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
        services.AddScoped(typeof(IWriteRepository<>), typeof(Repository.Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(Repository.Repository<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository.Repository<>));
        return services;
    }
}