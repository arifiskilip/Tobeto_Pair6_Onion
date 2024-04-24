using Core.DataAccess.Paging;
using Domain.Entities;

namespace Application.Services
{
	public interface IBrandService
	{
		Task<Brand> AddAsync(Brand brand);
		Task<IPaginatedList<Brand>> GetAllByPaginatedAsync(int index = 1, int size = 10);
	}
}
