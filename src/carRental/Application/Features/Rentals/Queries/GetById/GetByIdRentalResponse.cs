using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rentals.Queries.GetById;

public class GetByIdRentalResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
}