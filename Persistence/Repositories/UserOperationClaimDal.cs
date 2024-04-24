using Application.Repositories;
using Core.DataAccess.Repositories;
using Core.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class UserOperationClaimDal : RepositoryBase<UserOperationClaim, int, CarRentalTobetoContext>, IUserOperationClaimDal
	{
		public UserOperationClaimDal(CarRentalTobetoContext context) : base(context)
		{
		}
	}
}
