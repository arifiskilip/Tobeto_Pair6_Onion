using Core.DataAccess.Repositories;
using Core.Entities;

namespace Application.Repositories
{
	public interface IUserOperationClaimDal : IAsyncRepository<UserOperationClaim,int>, IRepository<UserOperationClaim,int>
	{
	}
}
