using Application.Features.Payments.Constants;
using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Payments.Commands.Delete;

public class DeletePaymentCommand : IRequest<DeletedPaymentResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletedPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public DeletePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<DeletedPaymentResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment? payment = await _paymentRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentBusinessRules.PaymentShouldExistWhenSelected(payment);

            await _paymentRepository.DeleteAsync(payment!);

            DeletedPaymentResponse response = _mapper.Map<DeletedPaymentResponse>(payment);
            return response;
        }
    }
}