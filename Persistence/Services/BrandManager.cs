using Application.Repositories;
using Application.Services;
using Core.DataAccess.Paging;
using Domain.Entities;

namespace Persistence.Services
{
	public class BrandManager : IBrandService
	{
		private readonly IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public async Task<Brand> AddAsync(Brand brand)
		{
			var result = await _brandDal.AddAsync(brand,includeProperties:x=>x.Model);
			return result;
		}

		public Task<IPaginatedList<Brand>> GetAllByPaginatedAsync(int index = 1, int size = 10)
		{
			throw new NotImplementedException();
		}
	}
}
