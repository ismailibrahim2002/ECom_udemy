using Ecom_lib.Dtos.Identity;
using FluentValidation;

namespace ECom_udemy.Validation.Idintity
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full Name is required.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invaild Email Format .");

            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required.")
                .MinimumLength(8).WithMessage("at least need to 8 charcters")
                .Matches(@"[A-Z]").WithMessage("must contins at least one uppercase lstter")
                .Matches(@"[a-z]").WithMessage("must contins at least one lowercase lstter")
                .Matches(@"\d").WithMessage("must contins at least one number")
                .Matches(@"[^\w]").WithMessage("must contins at least one special character");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("confirm password is required.")
                .Equal(x => x.Password).WithMessage("Pawwords not equals");
        }
    }

    public class LogInUserValidator : AbstractValidator<LogInUser>
    {
        public LogInUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email foramt");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
