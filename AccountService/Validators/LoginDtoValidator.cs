using AccountService.Data.Models;
using FluentValidation;

namespace AccountService.Validators;

public class LoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Email must be a valid address.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(1024).WithMessage("Password is too long.");
    }
}