using Core.DataAccess.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IIndividualCustomerDal : IAsyncRepository<IndividualCustomer, int>, IRepository<IndividualCustomer, int>
	{
	}
}
