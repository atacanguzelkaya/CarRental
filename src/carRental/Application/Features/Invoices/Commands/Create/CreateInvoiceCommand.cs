using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommand : IRequest<CreatedInvoiceResponse>, ILoggableRequest, ITransactionalRequest
{
    public required Guid CustomerId { get; set; }
    public required string No { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime RentalStartDate { get; set; }
    public required DateTime RentalEndDate { get; set; }
    public required short TotalRentalDate { get; set; }
    public required decimal RentalPrice { get; set; }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreatedInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CreatedInvoiceResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice invoice = _mapper.Map<Invoice>(request);

            await _invoiceRepository.AddAsync(invoice);

            CreatedInvoiceResponse response = _mapper.Map<CreatedInvoiceResponse>(invoice);
            return response;
        }
    }
}