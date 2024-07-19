using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Invoices.Queries.GetById;

public class GetByIdInvoiceQuery : IRequest<GetByIdInvoiceResponse>
{
    public Guid Id { get; set; }

    public class GetByIdInvoiceQueryHandler : IRequestHandler<GetByIdInvoiceQuery, GetByIdInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public GetByIdInvoiceQueryHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<GetByIdInvoiceResponse> Handle(GetByIdInvoiceQuery request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

            GetByIdInvoiceResponse response = _mapper.Map<GetByIdInvoiceResponse>(invoice);
            return response;
        }
    }
}