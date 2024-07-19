using FluentValidation;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.NameOnCard).NotEmpty();
        RuleFor(c => c.CcNumber).NotEmpty();
        RuleFor(c => c.ExpirationMonth).NotEmpty();
        RuleFor(c => c.ExpirationYear).NotEmpty();
        RuleFor(c => c.Cvv).NotEmpty();
    }
}