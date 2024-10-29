using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SalesService.Infrastructure.Context;

namespace SalesService.API;

public class DbContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var environment = GetEnvironment();
        
        if (environment is null)
            throw new ArgumentException($"Missing environment variable: {environment}.");

        var configuration = GetConfiguration(environment);

        var builder = new DbContextOptionsBuilder<Context>();
        var connectionString = GetConnectionString(configuration);
        builder.UseSqlServer(connectionString);
        
        return new Context(builder.Options);
    }
    
    public static string? GetEnvironment() => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    
    public static IConfigurationRoot GetConfiguration(string environment) => 
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
     
    public static string GetConnectionString(IConfigurationRoot configuration) =>
        configuration.GetConnectionString("Context");
}