namespace SalesService.Infrastructure.Mapping.Customer;

public class CustomerMap : IEntityTypeConfiguration<Domain.Entities.Customer.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Customer.Customer> builder)
    {
        builder.ToTable(nameof(Domain.Entities.Customer.Customer), Schemas.Customer)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnType(SqlColumnTypeHelper.UniqueIdentifier);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);
    }
}