using Core.CrossCuttingConcers.Exceptions.Types;
using Core.Utilities.Security.Hashing;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
	public class LoginCommand : IRequest<LoginResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }



		public class LoginCommandHandler 
		{
		}
	}
}
