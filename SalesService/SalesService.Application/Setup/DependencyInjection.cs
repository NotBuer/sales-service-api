using Microsoft.Extensions.DependencyInjection;
using SalesService.Application.Commands.Common;

namespace SalesService.Application.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAddCommandHandler<,,>), typeof(AddCommandHandler<,,>));
        return services;
    }
}