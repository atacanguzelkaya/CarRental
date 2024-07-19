using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Commands.Create;

public class CreatedColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}