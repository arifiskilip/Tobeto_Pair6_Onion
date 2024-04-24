using Core.DataAccess.Repositories;
using Core.Entities;

namespace Application.Repositories
{
	public interface IUserDal : IAsyncRepository<User,int>,IRepository<User,int>
	{
		Task<List<OperationClaim>> GetClaimsAsync(User user);
	}
}
