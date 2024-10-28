namespace SalesService.Infrastructure.Mapping.Inventory;

public class InventoryMap : IEntityTypeConfiguration<Domain.Entities.Inventory.Inventory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Inventory.Inventory> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Inventory.Inventory), Schemas.Inventory)
            .HasKey(x => x.ProductId);
    }
}