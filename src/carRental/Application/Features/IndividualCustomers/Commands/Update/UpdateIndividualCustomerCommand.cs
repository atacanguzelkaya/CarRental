using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommand : IRequest<UpdatedIndividualCustomerResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalIdentity { get; set; }

    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdatedIndividualCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public UpdateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository,
                                         IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<UpdatedIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(predicate: ic => ic.Id == request.Id, cancellationToken: cancellationToken);
            await _individualCustomerBusinessRules.IndividualCustomerShouldExistWhenSelected(individualCustomer);
            individualCustomer = _mapper.Map(request, individualCustomer);

            await _individualCustomerRepository.UpdateAsync(individualCustomer!);

            UpdatedIndividualCustomerResponse response = _mapper.Map<UpdatedIndividualCustomerResponse>(individualCustomer);
            return response;
        }
    }
}