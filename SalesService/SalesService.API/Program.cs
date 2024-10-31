using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.OpenApi.FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using SalesService.API;
using SalesService.Application.Requests.Common;
using SalesService.Application.Setup;
using SalesService.Application.Validations.Common;
using SalesService.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;


services
    .AddDbContext()
    .AddDependencyInjection();

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining(typeof(RequestValidator<IRequest>));
services.AddValidatorsFromAssemblies(ApplicationLayerAssembly.Assemblies);

#if DEBUG
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddFluentValidationRulesToSwagger();
#endif

var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.MapEndpoints();
app.UseHttpsRedirection();
app.Run();