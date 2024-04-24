using Core.DataAccess.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IModelDal : IAsyncRepository<Model, int>, IRepository<Model, int>
	{
	}
}
