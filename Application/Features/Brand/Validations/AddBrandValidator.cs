using FluentValidation;

namespace Application.Features
{
	public class AddBrandValidator : AbstractValidator<AddBrandCommand>
	{

        public AddBrandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Name).Must(StartsWithLetter).WithMessage("Lütfen geçerli bir marka giriniz."); ;
        }

		private bool StartsWithLetter(string arg)
		{
			//Bir harf ilemi başlıyor
			return char.IsLetter(arg[0]);
		}
	}
}
