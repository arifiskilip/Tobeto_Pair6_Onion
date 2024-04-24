using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class AddBrandCommand : IRequest<AddBrandResponse>
	{ 
        public string Name { get; set; }
        public int ModelId { get; set; }


        public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, AddBrandResponse>
		{
			private readonly IBrandService _brandService;
			private readonly BrandBusinessRules _brandBusinessRules;
			private readonly IMapper _mapper;

			public AddBrandCommandHandler(IBrandService brandService, BrandBusinessRules brandBusinessRules, IMapper mapper)
			{
				_brandService = brandService;
				_brandBusinessRules = brandBusinessRules;
				_mapper = mapper;
			}

			public async Task<AddBrandResponse> Handle(AddBrandCommand request, CancellationToken cancellationToken)
			{

				//Business Rules
				await _brandBusinessRules.DuplicateNameCheckAsync(request.Name);
				await _brandBusinessRules.IsModelAvailable(request.ModelId);

				Brand addedBrand = _mapper.Map<Brand>(request);
				await _brandService.AddAsync(addedBrand);
				return _mapper.Map<AddBrandResponse>(addedBrand);
			}
		}
	}
}
