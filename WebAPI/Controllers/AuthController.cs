using Application.Features.Auth.Commands.CorporateRegister;
using Application.Features.Auth.Commands.IndividualRegister;
using Application.Features.Auth.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> IndividualRegister([FromBody] IndividualRegisterCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CorporateRegister([FromBody] CorporateRegisterCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
