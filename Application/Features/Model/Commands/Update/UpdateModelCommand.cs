using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class UpdateModelCommand : IRequest<UpdateModelResponse>, ISecuredRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string[] RequiredRoles => ["Admin", "Model.Write"];

		public class UpdateModelHandler : IRequestHandler<UpdateModelCommand, UpdateModelResponse>
		{
			private readonly IModelDal _modelDal;
			private readonly IMapper _mapper;
			private readonly ModelBusinessRules _businessRules;

			public UpdateModelHandler(IMapper mapper, ModelBusinessRules businessRules, IModelDal modelDal)
			{
				_mapper = mapper;
				_businessRules = businessRules;
				_modelDal = modelDal;
			}
			public async Task<UpdateModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
			{
				

				Model? checkModel = await _modelDal.GetAsync(
					predicate: x => x.Id == request.Id);
				await _businessRules.IsSelectedModelAvailable(checkModel);
				await _businessRules.UpdateDuplicateNameCheckAsync(request.Name, request.Id);

				checkModel = _mapper.Map(request, checkModel);

				var updatedModel = await _modelDal.UpdateAsync(checkModel);

				return _mapper.Map<UpdateModelResponse>(updatedModel);
			}
		}
	}
}
