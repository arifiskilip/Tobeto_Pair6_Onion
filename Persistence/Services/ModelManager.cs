using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using Core.DataAccess.Paging;
using Domain.Entities;

namespace Persistence.Services
{
	public class ModelManager : IModelService
	{
		private readonly IModelDal _modelDal;

		public ModelManager(IModelDal modelDal)
		{
			_modelDal = modelDal;
		}

		public async Task<Model> AddAsync(Model model)
		{
			var addedModel = await _modelDal.AddAsync(model);
			return addedModel;
		}

		public async Task<IPaginatedList<Model>> GetAllByPaginatedAsync(int index = 1, int size = 10)
		{
			return await _modelDal.GetListByPaginatedAsync(index:index, size:size,
				orderBy:x=> x.OrderByDescending(x=>x.CreatedDate));
		}

		public async Task<Model> GetByIdAsync(int modelId)
		{
			var checkModel = await _modelDal.GetAsync(
				predicate: x => x.Id == modelId,
				enableTracking:true);
			if (checkModel != null)
			{
				return checkModel;
			}
			throw new NotFoundException("İlgili model mevcut değil!");
		}

		public async Task<bool> ModelIsAvailable(int modelId)
		{
			return await _modelDal.AnyAsync(x => x.Id == modelId);
		}

		public async Task RemoveAsync(int modelId)
		{
			var deletedModel = await GetByIdAsync(modelId);
			await _modelDal.DeleteAsync(deletedModel);
		}

		public async Task<Model> UpdateAsync(Model model)
		{
			var updatedModel = await _modelDal.UpdateAsync(model);
			return updatedModel;
		}
	}
}
