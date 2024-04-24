using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Features
{
	public class GetByIdModelCommand : IRequest<GetByIdModelResponse>
	{
        public int Id { get; set; }


		public class GetByIdModelHandler : IRequestHandler<GetByIdModelCommand, GetByIdModelResponse>
		{
			private readonly IModelService _modelService;
			private readonly IMapper _mapper;

			public GetByIdModelHandler(IModelService modelService, IMapper mapper)
			{
				_modelService = modelService;
				_mapper = mapper;
			}

			public async Task<GetByIdModelResponse> Handle(GetByIdModelCommand request, CancellationToken cancellationToken)
			{
				var model = await _modelService.GetByIdAsync(request.Id);

				return _mapper.Map<GetByIdModelResponse>(model);
			}
		}

	}
}
