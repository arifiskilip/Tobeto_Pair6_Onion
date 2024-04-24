using FluentValidation;

namespace Application.Features
{
	public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
	{
        public UpdateBrandValidator()
        {
            RuleFor(x=> x.Id).NotEmpty();
            RuleFor(x=> x.Name).NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x=> x.ModelId).NotEmpty();

        }
    }
}
