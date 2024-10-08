using FluentValidation;

namespace Application.Features.Rentals.Commands.Update;

public class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.RentStartDate).NotEmpty();
        RuleFor(c => c.RentEndDate).NotEmpty();
        RuleFor(c => c.RentStartKilometer).NotEmpty();
    }
}