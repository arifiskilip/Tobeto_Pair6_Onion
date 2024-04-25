using Application.Features.Auth.Commands.IndividualRegister;
using FluentValidation;

namespace Application.Features.Auth.Validations
{
	public class IndividualRegisterCommandValidator : AbstractValidator<IndividualRegisterCommand>
	{
        public IndividualRegisterCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.IdentityNumber).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.LastName).NotEmpty();

        }
    }
}
