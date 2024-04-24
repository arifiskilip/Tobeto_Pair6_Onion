using Application.Repositories;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;

namespace Application.Features
{
	public class ModelBusinessRules
	{
		private readonly IModelDal _modelDal;

		public ModelBusinessRules(IModelDal modelDal)
		{
			_modelDal = modelDal;
		}

		public async Task DuplicateNameCheckAsync(string name)
		{
			var check = await _modelDal
				.AnyAsync(x => x.Name.ToLower() == name.ToLower());
			if (check)
			{
				throw new BusinessException("Bu model adı zaten mevcut!");
			}
		}
		public async Task UpdateDuplicateNameCheckAsync(string name, int id)
		{
			var check = await _modelDal
				.GetAsync(x => x.Name.ToLower() == name.ToLower());
			if (check != null && check.Id != id)
			{
				throw new BusinessException("Bu model adı zaten mevcut!");
			}
		}

		public async Task IsSelectedModelAvailable(Model? model)
		{
			if (model == null) throw new BusinessException("Böyle bir model mevcut değil!");
		}
	}
}
