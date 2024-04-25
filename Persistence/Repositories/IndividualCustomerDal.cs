using Application.Repositories;
using Core.DataAccess.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class IndividualCustomerDal : RepositoryBase<IndividualCustomer, int, CarRentalTobetoContext>, IIndividualCustomerDal
	{
		public IndividualCustomerDal(CarRentalTobetoContext context) : base(context)
		{
		}
	}
}
