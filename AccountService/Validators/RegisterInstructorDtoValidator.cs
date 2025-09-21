using AccountService.Data.Models;
using FluentValidation;

namespace AccountService.Validators;

    public class RegisterInstructorDtoValidator : AbstractValidator<RegisterInstructorDto>
    {
        private const string EmailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
        private const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
    
        public RegisterInstructorDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(EmailPattern)
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^\+?[0-9\s\-\(\)]{7,}$")
                .WithMessage("Phone must contain only digits, spaces, +, - or parentheses and be at least 7 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(PasswordPattern)
                .WithMessage("Password must be at least 8 characters and include uppercase, lowercase, digit and special character.");
        }
    }