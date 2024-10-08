﻿using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity<Guid>
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
    public virtual CorporateCustomer? CorporateCustomer { get; set; }
    public virtual IndividualCustomer? IndividualCustomer { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }

    public Customer()
    {
        Invoices = new HashSet<Invoice>();
        Rentals = new HashSet<Rental>();
    }

    public Customer(Guid id, Guid userId)
        : this()
    {
        Id = id;
        UserId = userId;
    }
}
