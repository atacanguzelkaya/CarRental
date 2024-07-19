using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommand : IRequest<UpdatedCorporateCustomerResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required string CompanyName { get; set; }
    public required string TaxNo { get; set; }

    public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdatedCorporateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public UpdateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository,
                                         CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _mapper = mapper;
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<UpdatedCorporateCustomerResponse> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _corporateCustomerBusinessRules.CorporateCustomerShouldExistWhenSelected(corporateCustomer);
            corporateCustomer = _mapper.Map(request, corporateCustomer);

            await _corporateCustomerRepository.UpdateAsync(corporateCustomer!);

            UpdatedCorporateCustomerResponse response = _mapper.Map<UpdatedCorporateCustomerResponse>(corporateCustomer);
            return response;
        }
    }
}