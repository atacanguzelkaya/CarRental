using Application.Features.Invoices.Commands.Create;
using Application.Features.Invoices.Commands.Delete;
using Application.Features.Invoices.Commands.Update;
using Application.Features.Invoices.Queries.GetById;
using Application.Features.Invoices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Invoices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInvoiceCommand, Invoice>();
        CreateMap<Invoice, CreatedInvoiceResponse>();

        CreateMap<UpdateInvoiceCommand, Invoice>();
        CreateMap<Invoice, UpdatedInvoiceResponse>();

        CreateMap<DeleteInvoiceCommand, Invoice>();
        CreateMap<Invoice, DeletedInvoiceResponse>();

        CreateMap<Invoice, GetByIdInvoiceResponse>();

        CreateMap<Invoice, GetListInvoiceListItemDto>();
        CreateMap<IPaginate<Invoice>, GetListResponse<GetListInvoiceListItemDto>>();
    }
}