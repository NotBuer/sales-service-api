namespace SalesService.Infrastructure.Mapping.Customer;

public class CustomerMap : IEntityTypeConfiguration<Domain.Entities.Customer.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Customer.Customer> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Customer.Customer), Schemas.Customer)
            .HasKey(x => x.Id);
    }
}