using Application.Repositories;
using Application.Services;
using Core.Entities;
using Core.Utilities.Security.JWT;

namespace Persistence.Services
{
	public class AuthManager : IAuthService
	{
		private readonly IUserDal _userDal;
		private readonly ITokenHelper _tokenHelper;

		public AuthManager(IUserDal userDal, ITokenHelper tokenHelper)
		{
			_userDal = userDal;
			_tokenHelper = tokenHelper;
		}

		public async Task<AccessToken> CreateAccessTokenAsync(User user)
		{
			List<OperationClaim> userRoles = await _userDal.GetClaimsAsync(user);
			AccessToken token = _tokenHelper.CreateToken(user, userRoles);
			return token;
		}

		public async Task<bool> UserExistsAsync(string email)
		{
			return await _userDal.AnyAsync(x => x.Email.ToLower() == email.ToLower());
		}
	}
}
