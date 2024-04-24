using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class AddModelCommand : IRequest<AddModelResponse>
	{
		public string Name { get; set; }


		public class AddModelCommandHandler : IRequestHandler<AddModelCommand, AddModelResponse>
		{
			private readonly IModelDal _modelDal;
			private readonly IMapper _mapper;
			private readonly ModelBusinessRules _businessRules;

			public AddModelCommandHandler(IMapper mapper, ModelBusinessRules businessRules, IModelDal modelDal)
			{
				_mapper = mapper;
				_businessRules = businessRules;
				_modelDal = modelDal;
			}

			public async Task<AddModelResponse> Handle(AddModelCommand request, CancellationToken cancellationToken)
			{
				//Bussiness Rules
				await _businessRules.DuplicateNameCheckAsync(request.Name);

				Model model = _mapper.Map<Model>(request);
				await _modelDal.AddAsync(model);
				return _mapper.Map<AddModelResponse>(model);
			}
		}
	}
}
