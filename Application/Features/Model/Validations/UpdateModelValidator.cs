using FluentValidation;

namespace Application.Features
{
	internal class UpdateModelValidator : AbstractValidator<UpdateModelCommand>
	{
		public UpdateModelValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50);
			RuleFor(x => x.Name).Must(StartsWithLetter);
		}

		private bool StartsWithLetter(string arg)
		{
			//Bir harf ilemi başlıyor
			return !char.IsLetter(arg[0]);
		}
	}
}
