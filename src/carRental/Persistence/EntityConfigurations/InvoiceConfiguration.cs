using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(i => i.No).HasColumnName("No").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.RentalStartDate).HasColumnName("RentalStartDate").IsRequired();
        builder.Property(i => i.RentalEndDate).HasColumnName("RentalEndDate").IsRequired();
        builder.Property(i => i.TotalRentalDate).HasColumnName("TotalRentalDate").IsRequired();
        builder.Property(i => i.RentalPrice).HasColumnName("RentalPrice").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}