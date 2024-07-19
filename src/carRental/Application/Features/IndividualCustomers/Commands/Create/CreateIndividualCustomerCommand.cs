using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>, ILoggableRequest, ITransactionalRequest
{
    public required Guid CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalIdentity { get; set; }

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public CreateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository,
                                         IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request);

            await _individualCustomerRepository.AddAsync(individualCustomer);

            CreatedIndividualCustomerResponse response = _mapper.Map<CreatedIndividualCustomerResponse>(individualCustomer);
            return response;
        }
    }
}