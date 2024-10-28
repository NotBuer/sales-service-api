namespace SalesService.Infrastructure.Mapping.Inventory;

public class ProductMap : IEntityTypeConfiguration<Domain.Entities.Inventory.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Inventory.Product> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Inventory.Product), Schemas.Inventory)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.UniqueIdentifier);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP8S2);
        
        builder.Property(x => x.Discount)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP8S2);
        
        builder.Property(x => x.FinalPrice)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP10S2);
    }
}