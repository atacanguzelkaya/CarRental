using Application.Features.Rentals.Commands.Create;
using Application.Features.Rentals.Commands.Delete;
using Application.Features.Rentals.Commands.Update;
using Application.Features.Rentals.Queries.GetById;
using Application.Features.Rentals.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Rentals.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRentalCommand, Rental>();
        CreateMap<Rental, CreatedRentalResponse>();

        CreateMap<UpdateRentalCommand, Rental>();
        CreateMap<Rental, UpdatedRentalResponse>();

        CreateMap<DeleteRentalCommand, Rental>();
        CreateMap<Rental, DeletedRentalResponse>();

        CreateMap<Rental, GetByIdRentalResponse>();

        CreateMap<Rental, GetListRentalListItemDto>();
        CreateMap<IPaginate<Rental>, GetListResponse<GetListRentalListItemDto>>();
    }
}