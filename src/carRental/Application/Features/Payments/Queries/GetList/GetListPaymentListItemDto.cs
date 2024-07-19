using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Payments.Queries.GetList;

public class GetListPaymentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string NameOnCard { get; set; }
    public string CcNumber { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string Cvv { get; set; }
}