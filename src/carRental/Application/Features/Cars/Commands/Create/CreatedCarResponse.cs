using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Commands.Create;

public class CreatedCarResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ColorId { get; set; }
    public Guid ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
}