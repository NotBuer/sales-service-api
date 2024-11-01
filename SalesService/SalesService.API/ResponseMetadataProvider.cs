using System.Reflection;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.OpenApi.Models;
using SalesService.Application.Responses.Common;

namespace SalesService.API;

internal class ResponseMetadataProvider : IEndpointMetadataProvider
{
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        if (!typeof(IResponse).IsAssignableFrom(method.ReturnType)) return;
        
        builder.Metadata.Add(new OpenApiResponse
        {
            Description = "Default response structure data",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/json"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = $"{typeof(IResponse).FullName}",
                        Properties = DynamicallyMapProperties()
                    }
                }
            }
        });
    }

    private static Dictionary<string, OpenApiSchema> DynamicallyMapProperties()
    {
        var properties = typeof(Metadata).GetProperties();
        var dictionary = new Dictionary<string, OpenApiSchema>(properties.Length);
        foreach (var property in properties)
        {
            dictionary.Add(
                property.Name.ToLower(), 
                new OpenApiSchema
                {
                    Type = property.PropertyType.Name!.ToLower(),
                    Description = $"Response {property.Name.ToLower()}"
                });
        }
        return dictionary;
    }
}