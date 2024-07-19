using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommand : IRequest<CreatedRentalResponse>, ILoggableRequest, ITransactionalRequest
{
    public required Guid CarId { get; set; }
    public required Guid CustomerId { get; set; }
    public required DateTime RentStartDate { get; set; }
    public required DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public required int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }

    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public CreateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<CreatedRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            Rental rental = _mapper.Map<Rental>(request);

            await _rentalRepository.AddAsync(rental);

            CreatedRentalResponse response = _mapper.Map<CreatedRentalResponse>(rental);
            return response;
        }
    }
}