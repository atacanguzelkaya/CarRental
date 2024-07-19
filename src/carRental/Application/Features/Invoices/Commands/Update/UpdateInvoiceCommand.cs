using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommand : IRequest<UpdatedInvoiceResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required string No { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime RentalStartDate { get; set; }
    public required DateTime RentalEndDate { get; set; }
    public required short TotalRentalDate { get; set; }
    public required decimal RentalPrice { get; set; }

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, UpdatedInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<UpdatedInvoiceResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);
            invoice = _mapper.Map(request, invoice);

            await _invoiceRepository.UpdateAsync(invoice!);

            UpdatedInvoiceResponse response = _mapper.Map<UpdatedInvoiceResponse>(invoice);
            return response;
        }
    }
}