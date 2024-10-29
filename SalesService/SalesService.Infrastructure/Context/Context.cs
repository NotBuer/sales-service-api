namespace SalesService.Infrastructure.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Domain.Entities.Common.DomainEvent>();
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new Mapping.Sale.SaleMap());
        modelBuilder.ApplyConfiguration(new Mapping.Customer.CustomerMap());
        modelBuilder.ApplyConfiguration(new Mapping.Inventory.InventoryMap());
        modelBuilder.ApplyConfiguration(new Mapping.Inventory.ProductMap());
    }
}