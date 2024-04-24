using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class UpdateBrandCommand : IRequest<UpdateBrandResponse>
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public int ModelId { get; set; }


		public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
		{
			private readonly IBrandDal _brandDal;
			private readonly IMapper _mapper;
			private readonly BrandBusinessRules _brandBusinessRules;

			public UpdateBrandHandler(IBrandDal brandDal, IMapper mapper, BrandBusinessRules brandBusinessRules)
			{
				_brandDal = brandDal;
				_mapper = mapper;
				_brandBusinessRules = brandBusinessRules;
			}

			public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
			{
				Brand? brand = await _brandDal.GetAsync(
					predicate: x => x.Id == request.Id,
					enableTracking: true);
				await _brandBusinessRules.IsSelectedBrandAvailable(brand);
				await _brandBusinessRules.UpdateDuplicateNameCheckAsync(request.Name, request.Id);
				await _brandBusinessRules.IsModelAvailable(request.ModelId);

				brand = _mapper.Map(request, brand);
				var updatedBrand = await _brandDal.UpdateAsync(brand,includeProperties:x=> x.Model);
				return _mapper.Map<UpdateBrandResponse>(updatedBrand);
			}
		}
	}
}
