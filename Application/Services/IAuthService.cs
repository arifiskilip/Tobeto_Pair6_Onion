using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Application.Services
{
	public interface IAuthService
	{
		Task<bool> UserExistsAsync(string email);
		Task<AccessToken> CreateAccessTokenAsync(User user);
	}
}
