using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Invoices.Queries.GetList;

public class GetListInvoiceQuery : IRequest<GetListResponse<GetListInvoiceListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListInvoiceQueryHandler : IRequestHandler<GetListInvoiceQuery, GetListResponse<GetListInvoiceListItemDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetListInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInvoiceListItemDto>> Handle(GetListInvoiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Invoice> invoices = await _invoiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInvoiceListItemDto> response = _mapper.Map<GetListResponse<GetListInvoiceListItemDto>>(invoices);
            return response;
        }
    }
}