using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Application.Features.Auth.Commands.Login
{
	public class LoginResponse
	{
		public User User { get; set; }
		public AccessToken Token { get; set; }
	}
}
