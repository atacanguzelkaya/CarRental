using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Payments.Queries.GetById;

public class GetByIdPaymentQuery : IRequest<GetByIdPaymentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdPaymentQueryHandler : IRequestHandler<GetByIdPaymentQuery, GetByIdPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public GetByIdPaymentQueryHandler(IMapper mapper, IPaymentRepository paymentRepository, PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<GetByIdPaymentResponse> Handle(GetByIdPaymentQuery request, CancellationToken cancellationToken)
        {
            Payment? payment = await _paymentRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentBusinessRules.PaymentShouldExistWhenSelected(payment);

            GetByIdPaymentResponse response = _mapper.Map<GetByIdPaymentResponse>(payment);
            return response;
        }
    }
}