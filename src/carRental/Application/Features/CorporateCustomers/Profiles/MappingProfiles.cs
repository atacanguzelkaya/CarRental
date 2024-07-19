using Application.Features.CorporateCustomers.Commands.Create;
using Application.Features.CorporateCustomers.Commands.Delete;
using Application.Features.CorporateCustomers.Commands.Update;
using Application.Features.CorporateCustomers.Queries.GetById;
using Application.Features.CorporateCustomers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCorporateCustomerCommand, CorporateCustomer>();
        CreateMap<CorporateCustomer, CreatedCorporateCustomerResponse>();

        CreateMap<UpdateCorporateCustomerCommand, CorporateCustomer>();
        CreateMap<CorporateCustomer, UpdatedCorporateCustomerResponse>();

        CreateMap<DeleteCorporateCustomerCommand, CorporateCustomer>();
        CreateMap<CorporateCustomer, DeletedCorporateCustomerResponse>();

        CreateMap<CorporateCustomer, GetByIdCorporateCustomerResponse>();

        CreateMap<CorporateCustomer, GetListCorporateCustomerListItemDto>();
        CreateMap<IPaginate<CorporateCustomer>, GetListResponse<GetListCorporateCustomerListItemDto>>();
    }
}