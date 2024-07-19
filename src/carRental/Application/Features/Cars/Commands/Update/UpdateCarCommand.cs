using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommand : IRequest<UpdatedCarResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required Guid ColorId { get; set; }
    public required Guid ModelId { get; set; }
    public required CarState CarState { get; set; }
    public required int Kilometer { get; set; }
    public required short ModelYear { get; set; }
    public required string Plate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCars"];

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _carBusinessRules.CarShouldExistWhenSelected(car);
            car = _mapper.Map(request, car);

            await _carRepository.UpdateAsync(car!);

            UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(car);
            return response;
        }
    }
}