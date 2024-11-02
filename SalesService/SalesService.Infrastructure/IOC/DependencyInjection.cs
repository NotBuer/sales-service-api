using Microsoft.Extensions.DependencyInjection;
using SalesService.Domain.Events;
using SalesService.Domain.Events.Common;
using SalesService.Domain.Interfaces.Repository;
using SalesService.Infrastructure.Context;
using SalesService.Infrastructure.UnitOfWork;

namespace SalesService.Infrastructure.IOC;

public static class DependencyInjection
{
    private static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        return services.AddDbContext<Context.Context>(opt =>
        {
            opt.UseSqlServer(DbContextFactory.GetConnectionString(DbContextFactory.GetConfiguration()));
#if DEBUG
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();      
#endif
        });
    }
    
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddDatabaseContext();

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddScoped<IDomainEventHandler, DomainEventHandler>();
        
        services.AddScoped(typeof(IWriteRepository<>), typeof(Repository.Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(Repository.Repository<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository.Repository<>));
        return services;
    }
}