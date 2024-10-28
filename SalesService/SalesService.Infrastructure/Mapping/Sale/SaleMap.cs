namespace SalesService.Infrastructure.Mapping.Sale;

public class SaleMap : IEntityTypeConfiguration<Domain.Entities.Sale.Sale>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Sale.Sale> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Sale.Sale), Schemas.Sale)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.UniqueIdentifier);

        builder.Property(x => x.CustomerName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.ProductName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.SoldIn)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.Datetime);

        builder.Property(x => x.SoldBy)
            .IsRequired()
            .HasMaxLength(25);
        
        builder.Property(x => x.ProductAmount)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.Tinyint);
        
        builder.Property(x => x.ProductUnitPrice)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP8S2);
        
        builder.Property(x => x.ProductUnitDiscount)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP8S2);
        
        builder.Property(x => x.SaleTotalPrice)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.DecimalP10S2);
        
        builder.Property(x => x.SaleStatus)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.Tinyint);
    }
}