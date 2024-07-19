using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}