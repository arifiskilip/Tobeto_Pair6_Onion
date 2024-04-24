using Core.DataAccess.Paging;
using Domain.Entities;

namespace Application.Features
{
	public class GetAllModelByPaginatedResponse
	{
        public IPaginatedList<Model> PaginatedList { get; set; }
    }
}
