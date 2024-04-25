using Application.Repositories;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
	public class CorporateBusinessRuless
	{
		private readonly ICorporateCustomerDal _corporateCustomerDal;

		public CorporateBusinessRuless(ICorporateCustomerDal corporateCustomerDal)
		{
			_corporateCustomerDal = corporateCustomerDal;
		}

		public async Task DuplicateEmailCheckAsync(string email)
		{
			var check = await _corporateCustomerDal
				.AnyAsync(x => x.Email.ToLower() == email.ToLower());
			if (check)
			{
				throw new BusinessException("Bu email adresi zaten mevcut!");
			}
		}
		public async Task IsSelectedCorporateAvailable(CorporateCustomer? customer)
		{
			if (customer == null) throw new BusinessException("Bu kullanıcı mevcut değil!");
		}
	}
}
