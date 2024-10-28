namespace SalesService.Infrastructure.Mapping.Inventory;

public class ProductMap : IEntityTypeConfiguration<Domain.Entities.Inventory.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Inventory.Product> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Inventory.Product), Schemas.Inventory)
            .HasKey(x => x.Id);
    }
}