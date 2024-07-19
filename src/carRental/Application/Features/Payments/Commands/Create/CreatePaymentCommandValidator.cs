using FluentValidation;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.NameOnCard).NotEmpty();
        RuleFor(c => c.CcNumber).NotEmpty();
        RuleFor(c => c.ExpirationMonth).NotEmpty();
        RuleFor(c => c.ExpirationYear).NotEmpty();
        RuleFor(c => c.Cvv).NotEmpty();
    }
}