﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SalesService.Infrastructure.Context;

internal class DbContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration();
        var connectionString = GetConnectionString(configuration);
        
        var builder = new DbContextOptionsBuilder<Context>();
        builder.UseSqlServer(connectionString);
#if DEBUG
        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();      
#endif
        
        return new Context(builder.Options);
    }
    
    public static IConfigurationRoot GetConfiguration() =>
        new ConfigurationBuilder()
            .SetBasePath(@$"{Directory.GetParent(Directory.GetCurrentDirectory())}\SalesService.API")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build(); 
     
    public static string GetConnectionString(IConfigurationRoot configuration) =>
        configuration.GetConnectionString("Context") ?? throw new InvalidOperationException("Connection string 'Context' not found.");
}