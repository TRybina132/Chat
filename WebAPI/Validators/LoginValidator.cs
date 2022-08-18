using Core.ViewModels;
using FluentValidation;

namespace WebAPI.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Username)
                .NotEmpty()
                    .WithMessage("Username required")
                .MinimumLength(4)
                    .WithMessage("Must be at least 4 characters")
                .MaximumLength(24)
                    .WithMessage("Must be no more than 24 characters");

            RuleFor(login => login.Password)
                .NotEmpty()
                    .WithMessage("Password required")
                .MinimumLength(4)
                    .WithMessage("Must be at least 4 characters")
                .MaximumLength(14)
                    .WithMessage("Must be no more than 14 characters"); ;
        }
    }
}
