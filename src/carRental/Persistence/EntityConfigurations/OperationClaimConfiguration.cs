using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Brands.Constants;
using Application.Features.Cars.Constants;
using Application.Features.Colors.Constants;
using Application.Features.CorporateCustomers.Constants;
using Application.Features.Customers.Constants;
using Application.Features.Fuels.Constants;
using Application.Features.IndividualCustomers.Constants;
using Application.Features.Invoices.Constants;
using Application.Features.Models.Constants;
using Application.Features.Payments.Constants;
using Application.Features.Rentals.Constants;
using Application.Features.Transmissions.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Brands CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cars CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Colors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ColorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Read },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Write },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Create },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Update },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CorporateCustomers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CorporateCustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Customers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Fuels CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FuelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Read },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Write },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Create },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Update },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region IndividualCustomers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Admin },
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Read },
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Write },
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Create },
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Update },
                new() { Id = ++lastId, Name = IndividualCustomersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Invoices CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Read },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Write },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Create },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Update },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Payments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Read },
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Write },
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Create },
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Update },
                new() { Id = ++lastId, Name = PaymentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Rentals CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RentalsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RentalsOperationClaims.Read },
                new() { Id = ++lastId, Name = RentalsOperationClaims.Write },
                new() { Id = ++lastId, Name = RentalsOperationClaims.Create },
                new() { Id = ++lastId, Name = RentalsOperationClaims.Update },
                new() { Id = ++lastId, Name = RentalsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Transmissions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Read },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Write },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Create },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Update },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
