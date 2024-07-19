using Application.Features.Invoices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Invoices.Rules;

public class InvoiceBusinessRules : BaseBusinessRules
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ILocalizationService _localizationService;

    public InvoiceBusinessRules(IInvoiceRepository invoiceRepository, ILocalizationService localizationService)
    {
        _invoiceRepository = invoiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InvoicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InvoiceShouldExistWhenSelected(Invoice? invoice)
    {
        if (invoice == null)
            await throwBusinessException(InvoicesBusinessMessages.InvoiceNotExists);
    }

    public async Task InvoiceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InvoiceShouldExistWhenSelected(invoice);
    }
}