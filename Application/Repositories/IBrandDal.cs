
using Core.DataAccess.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IBrandDal : IAsyncRepository<Brand,int>,IRepository<Brand,int>
	{
	}
}
