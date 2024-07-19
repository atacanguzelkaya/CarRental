using FluentValidation;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.No).NotEmpty();
        RuleFor(c => c.CreatedDate).NotEmpty();
        RuleFor(c => c.RentalStartDate).NotEmpty();
        RuleFor(c => c.RentalEndDate).NotEmpty();
        RuleFor(c => c.TotalRentalDate).NotEmpty();
        RuleFor(c => c.RentalPrice).NotEmpty();
    }
}