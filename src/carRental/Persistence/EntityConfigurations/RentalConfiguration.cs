using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(r => r.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(r => r.RentStartDate).HasColumnName("RentStartDate").IsRequired();
        builder.Property(r => r.RentEndDate).HasColumnName("RentEndDate").IsRequired();
        builder.Property(r => r.ReturnDate).HasColumnName("ReturnDate");
        builder.Property(r => r.RentStartKilometer).HasColumnName("RentStartKilometer").IsRequired();
        builder.Property(r => r.RentEndKilometer).HasColumnName("RentEndKilometer");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}