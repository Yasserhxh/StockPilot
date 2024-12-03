using FluentValidation;
using StockPilot.Api.Application.AppClient.Command;

namespace StockPilot.Api.Application.AppClient.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.ClientNom)
                .NotEmpty().WithMessage("Name is Required")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

            RuleFor(x => x.ClientEmail)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Invalid email format")
           .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.ClientPassword)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .MaximumLength(100).WithMessage("Password cannot exceed 100 characters");

            RuleFor(x => x.ClientTelephone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Invalid phone number format");
        }
    }
}
