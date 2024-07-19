using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(p => p.NameOnCard).HasColumnName("NameOnCard").IsRequired();
        builder.Property(p => p.CcNumber).HasColumnName("CcNumber").IsRequired();
        builder.Property(p => p.ExpirationMonth).HasColumnName("ExpirationMonth").IsRequired();
        builder.Property(p => p.ExpirationYear).HasColumnName("ExpirationYear").IsRequired();
        builder.Property(p => p.Cvv).HasColumnName("Cvv").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}