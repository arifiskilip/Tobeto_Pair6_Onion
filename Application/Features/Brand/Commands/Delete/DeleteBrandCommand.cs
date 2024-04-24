using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class DeleteBrandCommand : IRequest<DeleteBrandResponse>
	{
        public int Id { get; set; }


		public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
		{
			private readonly IBrandDal _brandDal;
			private readonly BrandBusinessRules _businessRules;

			public DeleteBrandHandler(IBrandDal brandDal, BrandBusinessRules businessRules)
			{
				_brandDal = brandDal;
				_businessRules = businessRules;
			}

			public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
			{
				Brand? checkBrand = await _brandDal.GetAsync(
					predicate: x => x.Id == request.Id,
					enableTracking:true);

				await _businessRules.IsSelectedBrandAvailable(checkBrand);
				await _brandDal.DeleteAsync(checkBrand);

				return new()
				{
					Message = $"{request.Id}'ye sahip marka başarıyla silindi"
				};
			}
		}
	}
}
