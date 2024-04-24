using Application.Repositories;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class DeleteModelCommand : IRequest<DeleteModelResponse>
	{
        public int Id { get; set; }


		public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponse>
		{
			private readonly IModelDal _modelDal;
			private readonly ModelBusinessRules _businessRules;

			public DeleteModelHandler(IModelDal modelDal, ModelBusinessRules businessRules)
			{
				_modelDal = modelDal;
				_businessRules = businessRules;
			}

			public async Task<DeleteModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
			{
				Model? model = await _modelDal.GetAsync(
					predicate:x=>x.Id == request.Id);

				await _businessRules.IsSelectedModelAvailable(model);

				await _modelDal.DeleteAsync(model);

				return new()
				{
					Message = $"{request.Id}'ye sahip model başarıyla silindi"
				};
			}
		}
	}
}
