using Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ModelsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ModelsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddModelCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllByPaginated([FromQuery] GetAllModelByPaginatedCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Update([FromBody] UpdateModelCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Delete([FromQuery] DeleteModelCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> GetById([FromQuery] GetByIdModelCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
