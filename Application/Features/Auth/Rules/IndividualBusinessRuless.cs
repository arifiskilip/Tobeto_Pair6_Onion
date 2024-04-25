using Application.Repositories;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
	public class IndividualBusinessRuless
	{
		private readonly IIndividualCustomerDal _ındividualCustomerDal;

		public IndividualBusinessRuless(IIndividualCustomerDal ındividualCustomerDal)
		{
			_ındividualCustomerDal = ındividualCustomerDal;
		}

		public async Task DuplicateEmailCheckAsync(string email)
		{
			var check = await _ındividualCustomerDal
				.AnyAsync(x => x.Email.ToLower() == email.ToLower());
			if (check)
			{
				throw new BusinessException("Bu email adresi zaten mevcut!");
			}
		}
		public async Task DuplicateIdentityNumberCheckAsync(string identityNumber)
		{
			var check = await _ındividualCustomerDal
				.AnyAsync(x => x.IdentityNumber.ToLower() == identityNumber.ToLower());
			if (check)
			{
				throw new BusinessException("Bu kimlik numarası zaten mevcut!");
			}
		}
		public async Task IsSelectedBrandAvailable(IndividualCustomer? customer)
		{
			if (customer == null) throw new BusinessException("Bu kullanıcı mevcut değil!");
		}
	}
}
