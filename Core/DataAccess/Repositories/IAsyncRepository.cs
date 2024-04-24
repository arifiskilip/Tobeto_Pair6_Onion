using Core.DataAccess.Paging;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories
{
	public interface IAsyncRepository<TEntity,TId> : IQuery<TEntity>
		where TEntity : Entity<TId>
	{
		Task<TEntity?> GetAsync(
		Expression<Func<TEntity, bool>> predicate,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool enableTracking = false,
		CancellationToken cancellationToken = default);

		Task<IPaginatedList<TEntity>> GetListByPaginatedAsync(
			Expression<Func<TEntity, bool>>? predicate = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
			int index = 1,
			int size = 10,
			bool enableTracking = false,
			CancellationToken cancellationToken = default
		);
		Task<IQueryable<TEntity>> GetListAsync(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
		bool enableTracking = false,
		CancellationToken cancellationToken = default
	);

		Task<bool> AnyAsync(
		   Expression<Func<TEntity, bool>> predicate,
		   CancellationToken cancellationToken = default
	   );

		Task<TEntity> AddAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties);

		Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

		Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties);

		Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

		Task<TEntity> DeleteAsync(TEntity entity);

		Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities);
	}
}
