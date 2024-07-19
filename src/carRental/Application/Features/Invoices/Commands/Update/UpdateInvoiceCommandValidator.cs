using FluentValidation;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.No).NotEmpty();
        RuleFor(c => c.CreatedDate).NotEmpty();
        RuleFor(c => c.RentalStartDate).NotEmpty();
        RuleFor(c => c.RentalEndDate).NotEmpty();
        RuleFor(c => c.TotalRentalDate).NotEmpty();
        RuleFor(c => c.RentalPrice).NotEmpty();
    }
}