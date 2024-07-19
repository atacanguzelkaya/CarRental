using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CorporateCustomer : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }

    public virtual Customer Customer { get; set; }

    public CorporateCustomer() { }

    public CorporateCustomer(Guid id, Guid customerId, string companyName, string taxNo)
        : base(id)
    {
        CustomerId = customerId;
        CompanyName = companyName;
        TaxNo = taxNo;
    }
}
