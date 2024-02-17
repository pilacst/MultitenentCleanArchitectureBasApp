using FluentValidation;

namespace Inoflix.Web.Application.Features.Users.Command
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Invalid Email.");
            RuleFor(c => c.UserName).NotNull().NotEmpty().WithMessage("Username must not be empty.");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("Password must not be empty.");
        }
    }
}
