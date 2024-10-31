using SalesService.API.Endpoints.Customer;
using SalesService.API.Endpoints.Inventory;
using SalesService.API.Endpoints.Sale;

namespace SalesService.API;

internal static class Mapping
{
    internal static WebApplication MapEndpoints(this WebApplication app)
    {
        Customer.Map(app);
        
        Inventory.Map(app);
        Product.Map(app);
        
        Sale.Map(app);
        
        return app;
    }
}