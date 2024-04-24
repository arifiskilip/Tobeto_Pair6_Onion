using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Features
{
	public class GetAllModelByPaginatedCommand:IRequest<GetAllModelByPaginatedResponse>
	{
		public int Index { get; set; } = 1;
		public int Size { get; set; } = 10;


		public class GetAllModelByPaginatedHandler : IRequestHandler<GetAllModelByPaginatedCommand, GetAllModelByPaginatedResponse>
		{
			private readonly IModelService _modelService;

			public GetAllModelByPaginatedHandler(IModelService modelService)
			{
				_modelService = modelService;
			}

			public async Task<GetAllModelByPaginatedResponse> Handle(GetAllModelByPaginatedCommand request, CancellationToken cancellationToken)
			{
				var result = await _modelService.GetAllByPaginatedAsync(request.Index, request.Size);
				return new()
				{
					PaginatedList = result
				};
			}
		}

	}
}
