using Core.DataAccess.Paging;
using Domain.Entities;

namespace Application.Services
{
	public interface IModelService
	{
		Task<Model> AddAsync(Model model);
		Task<bool> ModelIsAvailable(int modelId);
		Task<IPaginatedList<Model>> GetAllByPaginatedAsync(int index=1, int size=10);
		Task RemoveAsync(int modelId);
		Task<Model> GetByIdAsync(int modelId);
		Task<Model> UpdateAsync(Model model);
	}
}
