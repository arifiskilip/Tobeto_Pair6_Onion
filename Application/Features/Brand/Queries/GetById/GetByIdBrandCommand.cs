using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
	public class GetByIdBrandCommand : IRequest<GetByIdBrandResponse>, ISecuredRequest
	{
        public int Id { get; set; }
		public string[] RequiredRoles => ["Admin", "Brand.Read"];

		public class GetByIdBrandHandler : IRequestHandler<GetByIdBrandCommand, GetByIdBrandResponse>
		{
			private readonly IBrandDal _brandDal;
			private readonly IMapper _mapper;
			private readonly BrandBusinessRules _businessRules;

			public GetByIdBrandHandler(IBrandDal brandDal, IMapper mapper, BrandBusinessRules businessRules)
			{
				_brandDal = brandDal;
				_mapper = mapper;
				_businessRules = businessRules;
			}
			public async Task<GetByIdBrandResponse> Handle(GetByIdBrandCommand request, CancellationToken cancellationToken)
			{
				Brand? checkBrand = await _brandDal.GetAsync(
					predicate: x => x.Id == request.Id,
					include: x => x.Include(x => x.Model));

				await _businessRules.IsSelectedBrandAvailable(checkBrand);

				return _mapper.Map<GetByIdBrandResponse>(checkBrand);
			}
		}

	}
}
