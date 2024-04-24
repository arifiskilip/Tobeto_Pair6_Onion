using Core.DataAccess.Paging;
using Core.Entities;

namespace Application.Services
{
	public interface IUserService
	{
		Task<User> AddAsync(User user);
		Task DeleteAsync(User user);
		Task<User> UpdateAsync(User user);
		Task<IPaginatedList<User>> GetAllAsync();
		Task<User> GetByUserIdAsync(int userId);
		Task<List<OperationClaim>> GetClaimsAsync(User user);
		Task<User> GetByMailAsync(string email);
	}
}
