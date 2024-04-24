using FluentValidation;

namespace Application.Features
{
	public class DeleteBrandValidator : AbstractValidator<DeleteBrandCommand>
	{
        public DeleteBrandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
