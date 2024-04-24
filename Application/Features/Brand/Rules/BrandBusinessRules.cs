using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using Domain.Entities;

namespace Application.Features
{
	public class BrandBusinessRules
	{
		private readonly IBrandDal _brandDal;
		private readonly IModelService _modelService;

		public BrandBusinessRules(IBrandDal brandDal, IModelService modelService)
		{
			_brandDal = brandDal;
			_modelService = modelService;
		}

		public async Task DuplicateNameCheckAsync(string name)
		{
			var check = await _brandDal
				.AnyAsync(x => x.Name.ToLower() == name.ToLower());
			if (check)
			{
				throw new BusinessException("Bu marka adı zaten mevcut!");
			}
		}
		public async Task UpdateDuplicateNameCheckAsync(string name, int id)
		{
			var check = await _brandDal
				.GetAsync(x => x.Name.ToLower() == name.ToLower());
			if (check != null && check.Id != id)
			{
				throw new BusinessException("Bu marka adı zaten mevcut!");
			}
		}
		// Eklenecek || Güncellenecek model mevcut mu ?
		public async Task IsModelAvailable(int modelId)
		{
			var check = await _modelService.ModelIsAvailable(modelId);
			if (!check)
			{
				throw new BusinessException("Bu markaya ait model mevcut değil!");
			}
		}

		public async Task IsSelectedBrandAvailable(Brand? brand)
		{
			if (brand == null) throw new BusinessException("Bu marka mevcut değil!");
		}
	}
}
