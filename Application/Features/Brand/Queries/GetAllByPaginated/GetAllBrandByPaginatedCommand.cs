using Application.Repositories;
using Application.Services;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
	public class GetAllBrandByPaginatedCommand : IRequest<GetAllBrandByPaginatedResponse>, ISecuredRequest
	{
        public int Index { get; set; } = 1;
        public int Size { get; set; } = 10;
		public string[] RequiredRoles => ["Admin", "Brand.Read"];

		public class GetAllBrandByPaginatedHandler : IRequestHandler<GetAllBrandByPaginatedCommand, GetAllBrandByPaginatedResponse>
		{
			private readonly IBrandDal _brandDal;

			public GetAllBrandByPaginatedHandler(IBrandDal brandDal)
			{
				_brandDal = brandDal;
			}
			public async Task<GetAllBrandByPaginatedResponse> Handle(GetAllBrandByPaginatedCommand request, CancellationToken cancellationToken)
			{
				var result = await _brandDal.GetListByPaginatedAsync(index:request.Index,size:request.Size,include:x=> x.Include(x=>x.Model));
				return new()
				{
					PaginatedList = result
				};
			}
		}

	}
}
