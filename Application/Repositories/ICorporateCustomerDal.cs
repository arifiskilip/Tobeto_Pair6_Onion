using Core.DataAccess.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface ICorporateCustomerDal : IAsyncRepository<CorporateCustomer, int>, IRepository<CorporateCustomer, int>
	{
	}
}
