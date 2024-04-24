using Application.Repositories;
using Core.DataAccess.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Data;

namespace Persistence.Repositories
{
	public class UserDal : RepositoryBase<User,int,CarRentalTobetoContext> ,IUserDal
	{
		public UserDal(CarRentalTobetoContext context) : base(context)
		{
		}

		public async Task<List<OperationClaim>> GetClaimsAsync(User user)
		{
			var result = from oc in _context.Set<OperationClaim>()
						 join uoc in _context.Set<UserOperationClaim>()
							 on oc.Id equals uoc.OperationClaimId
			where uoc.UserId == user.Id
						 select new OperationClaim { Id = oc.Id, Name = oc.Name };
			return await result.ToListAsync();
		}
	}
}
