using Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class BrandsController : BaseController
	{

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddBrandCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllBrandByPaginatedCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}


		[HttpGet]
		public async Task<IActionResult> GetById([FromQuery] GetByIdBrandCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
