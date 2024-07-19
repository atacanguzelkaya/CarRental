using Application.Features.Payments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Payments.Rules;

public class PaymentBusinessRules : BaseBusinessRules
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILocalizationService _localizationService;

    public PaymentBusinessRules(IPaymentRepository paymentRepository, ILocalizationService localizationService)
    {
        _paymentRepository = paymentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PaymentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PaymentShouldExistWhenSelected(Payment? payment)
    {
        if (payment == null)
            await throwBusinessException(PaymentsBusinessMessages.PaymentNotExists);
    }

    public async Task PaymentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Payment? payment = await _paymentRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PaymentShouldExistWhenSelected(payment);
    }
}