using Application.Repositories;
using Application.Services;
using Core.Entities;

namespace Persistence.Services
{
	public class UserUserOperationClaimManager : IUserOperationClaimService
	{
		private readonly IUserOperationClaimDal _userOperationClaimDal;

		public UserUserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
		{
			_userOperationClaimDal = userOperationClaimDal;
		}

		public async Task AddRangeUserRoleAsync(List<UserOperationClaim> userOperationClaims)
		{
			await _userOperationClaimDal.AddRangeAsync(userOperationClaims);
		}

		public async Task AddUserRoleAsync(UserOperationClaim userOperationClaim)
		{
			await _userOperationClaimDal.AddAsync(userOperationClaim);
		}
	}
}
