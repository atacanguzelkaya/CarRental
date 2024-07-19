using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommand : IRequest<UpdatedPaymentResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required string NameOnCard { get; set; }
    public required string CcNumber { get; set; }
    public required string ExpirationMonth { get; set; }
    public required string ExpirationYear { get; set; }
    public required string Cvv { get; set; }

    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatedPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<UpdatedPaymentResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment? payment = await _paymentRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentBusinessRules.PaymentShouldExistWhenSelected(payment);
            payment = _mapper.Map(request, payment);

            await _paymentRepository.UpdateAsync(payment!);

            UpdatedPaymentResponse response = _mapper.Map<UpdatedPaymentResponse>(payment);
            return response;
        }
    }
}