using Application.Features.Auth.Commands.Login;
using FluentValidation;

namespace Application.Features.Auth.Validations
{
	public class LoginCommandValidator : AbstractValidator<LoginCommand>
	{
        public LoginCommandValidator()
        {
            RuleFor(x=> x.Email).NotEmpty();
            RuleFor(x=> x.Password).NotEmpty();
        }
    }
}
