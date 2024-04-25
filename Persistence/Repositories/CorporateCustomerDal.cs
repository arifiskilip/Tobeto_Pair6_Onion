using Application.Repositories;
using Core.DataAccess.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CorporateCustomerDal : RepositoryBase<CorporateCustomer, int, CarRentalTobetoContext>, ICorporateCustomerDal
	{
		public CorporateCustomerDal(CarRentalTobetoContext context) : base(context)
		{
		}
	}
}
