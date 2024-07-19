using NArchitecture.Core.Application.Responses;

namespace Application.Features.Payments.Queries.GetById;

public class GetByIdPaymentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string NameOnCard { get; set; }
    public string CcNumber { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string Cvv { get; set; }
}