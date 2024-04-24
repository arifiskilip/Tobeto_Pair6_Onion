using Application.Repositories;
using Core.DataAccess.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class BrandDal : RepositoryBase<Brand, int, CarRentalTobetoContext>, IBrandDal
	{
		public BrandDal(CarRentalTobetoContext context) : base(context)
		{
		}
	}
}
