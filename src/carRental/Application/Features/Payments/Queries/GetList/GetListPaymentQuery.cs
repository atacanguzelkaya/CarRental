using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Payments.Queries.GetList;

public class GetListPaymentQuery : IRequest<GetListResponse<GetListPaymentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPaymentQueryHandler : IRequestHandler<GetListPaymentQuery, GetListResponse<GetListPaymentListItemDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetListPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPaymentListItemDto>> Handle(GetListPaymentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Payment> payments = await _paymentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPaymentListItemDto> response = _mapper.Map<GetListResponse<GetListPaymentListItemDto>>(payments);
            return response;
        }
    }
}