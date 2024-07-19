using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;
public class Payment:Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public string NameOnCard { get; set; }
    public string CcNumber { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string Cvv { get; set; }
    public virtual Customer Customer { get; set; }

    public Payment() { }

    public Payment(
        Guid id,
        Guid customerId,
        string nameOnCard,
        string ccNumber,
        string expirationMonth,
        string expirationYear,
        string cvv
    )
        : this()
    {
        Id = id;
        CustomerId = customerId;
        NameOnCard = nameOnCard;
        CcNumber = ccNumber;
        ExpirationMonth = expirationMonth;
        ExpirationYear = expirationYear;
        Cvv = cvv;
    }
}