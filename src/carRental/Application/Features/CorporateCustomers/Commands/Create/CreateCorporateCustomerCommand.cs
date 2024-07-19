using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>, ILoggableRequest, ITransactionalRequest
{
    public required Guid CustomerId { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNo { get; set; }

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public CreateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository,
                                         CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _mapper = mapper;
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            CorporateCustomer corporateCustomer = _mapper.Map<CorporateCustomer>(request);

            await _corporateCustomerRepository.AddAsync(corporateCustomer);

            CreatedCorporateCustomerResponse response = _mapper.Map<CreatedCorporateCustomerResponse>(corporateCustomer);
            return response;
        }
    }
}