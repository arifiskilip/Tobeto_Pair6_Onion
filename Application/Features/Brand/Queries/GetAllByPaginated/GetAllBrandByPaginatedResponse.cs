using Core.DataAccess.Paging;
using Domain.Entities;

namespace Application.Features
{
	public class GetAllBrandByPaginatedResponse
	{
		public IPaginatedList<Brand> PaginatedList { get; set; }
	}
}
