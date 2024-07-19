using FluentValidation;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.RentStartDate).NotEmpty();
        RuleFor(c => c.RentEndDate).NotEmpty();
        RuleFor(c => c.RentStartKilometer).NotEmpty();
    }
}