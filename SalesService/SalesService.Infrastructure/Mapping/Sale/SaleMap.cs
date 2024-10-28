namespace SalesService.Infrastructure.Mapping.Sale;

public class SaleMap : IEntityTypeConfiguration<Domain.Entities.Sale.Sale>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Sale.Sale> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Sale.Sale), Schemas.Sale)
            .HasKey(x => x.Id);
    }
}