using Application.Features.IndividualCustomers.Commands.Create;
using Application.Features.IndividualCustomers.Commands.Delete;
using Application.Features.IndividualCustomers.Commands.Update;
using Application.Features.IndividualCustomers.Queries.GetById;
using Application.Features.IndividualCustomers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>();
        CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>();

        CreateMap<UpdateIndividualCustomerCommand, IndividualCustomer>();
        CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>();

        CreateMap<DeleteIndividualCustomerCommand, IndividualCustomer>();
        CreateMap<IndividualCustomer, DeletedIndividualCustomerResponse>();

        CreateMap<IndividualCustomer, GetByIdIndividualCustomerResponse>();

        CreateMap<IndividualCustomer, GetListIndividualCustomerListItemDto>();
        CreateMap<IPaginate<IndividualCustomer>, GetListResponse<GetListIndividualCustomerListItemDto>>();
    }
}