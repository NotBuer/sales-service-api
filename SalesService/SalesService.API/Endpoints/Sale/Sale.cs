﻿namespace SalesService.API.Endpoints.Sale;

internal static partial class Sale
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("sale", Post);
    }
}