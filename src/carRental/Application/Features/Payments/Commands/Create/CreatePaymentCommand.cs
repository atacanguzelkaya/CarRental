using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommand : IRequest<CreatedPaymentResponse>, ILoggableRequest, ITransactionalRequest
{
    public required Guid CustomerId { get; set; }
    public required string NameOnCard { get; set; }
    public required string CcNumber { get; set; }
    public required string ExpirationMonth { get; set; }
    public required string ExpirationYear { get; set; }
    public required string Cvv { get; set; }

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatedPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<CreatedPaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = _mapper.Map<Payment>(request);

            await _paymentRepository.AddAsync(payment);

            CreatedPaymentResponse response = _mapper.Map<CreatedPaymentResponse>(payment);
            return response;
        }
    }
}