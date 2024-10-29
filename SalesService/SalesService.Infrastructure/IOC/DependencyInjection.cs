using Microsoft.Extensions.DependencyInjection;

namespace SalesService.Infrastructure.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services)
    {
        return services;
    }
}