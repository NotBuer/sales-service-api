namespace SalesService.API.JsonSerialization;

internal static class JsonSerializerExtension
{
    internal static IServiceCollection AddCustomJsonSerialization(this IServiceCollection services)
    {
        return services.ConfigureHttpJsonOptions(opt =>
        {
            opt.SerializerOptions.TypeInfoResolverChain.Insert(0, new CustomerJsonSerializerContext());
        });
    }
}