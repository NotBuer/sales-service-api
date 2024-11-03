using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SalesService.Application.Commands.Common;
using SalesService.Application.Requests.Common;
using SalesService.Application.Services.Common;
using SalesService.Application.Validations.Common;

namespace SalesService.Application.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(ApplicationLayerAssembly.Assemblies);
        services.AddScoped(typeof(IValidator<>), typeof(RequestValidator<>));
        
        services.AddScoped(typeof(IAddCommandHandler<,,,>), typeof(AddCommandHandler<,,,>));
        services.AddScoped(typeof(IUpdateCommandHandler<,,,>), typeof(UpdateCommandHandler<,,,>));
        services.AddScoped(typeof(IDeleteCommandHandler<,,,>), typeof(DeleteCommandHandler<,,,>));

        services.AddScoped(typeof(IRequestHandlerService<,,>), typeof(RequestHandlerService<,,>));
        
        return services;
    }
}