using FluentValidation;

namespace Application.Features
{
	public class AddModelValidator : AbstractValidator<AddModelCommand>
	{
		public AddModelValidator()
		{
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
