using Application.Repositories;
using Core.DataAccess.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class ModelDal : RepositoryBase<Model, int, CarRentalTobetoContext>, IModelDal
	{
		public ModelDal(CarRentalTobetoContext context) : base(context)
		{
		}
	}
}
