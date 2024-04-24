using FluentValidation;

namespace Application.Features
{
	public class DeleteModelValidator : AbstractValidator<DeleteModelCommand>
	{
        public DeleteModelValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
        }
    }
}
