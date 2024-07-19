using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class IndividualCustomer : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public virtual Customer Customer { get; set; }

    public IndividualCustomer() { }

    public IndividualCustomer(Guid id, Guid customerId, string firstName, string lastName, string nationalIdentity)
        : base(id)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        NationalIdentity = nationalIdentity;
    }
}
