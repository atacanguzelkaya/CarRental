using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Rentals.Commands.Update;

public class UpdateRentalCommand : IRequest<UpdatedRentalResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid CarId { get; set; }
    public required Guid CustomerId { get; set; }
    public required DateTime RentStartDate { get; set; }
    public required DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public required int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }

    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, UpdatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public UpdateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<UpdatedRentalResponse> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            Rental? rental = await _rentalRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBusinessRules.RentalShouldExistWhenSelected(rental);
            rental = _mapper.Map(request, rental);

            await _rentalRepository.UpdateAsync(rental!);

            UpdatedRentalResponse response = _mapper.Map<UpdatedRentalResponse>(rental);
            return response;
        }
    }
}