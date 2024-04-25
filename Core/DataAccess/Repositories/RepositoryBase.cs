using Core.DataAccess.Paging;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories;

public class RepositoryBase<TEntity, TId, TContext>
	: IRepository<TEntity, TId>, IAsyncRepository<TEntity, TId>
	where TEntity : Entity<TId>
	where TContext : DbContext
{
	protected DbSet<TEntity> _entity;
	protected readonly TContext _context;
	public RepositoryBase(TContext context)
	{
		_context = context;
		_entity = _context.Set<TEntity>();
	}

	public TEntity Add(TEntity entity)
	{
		_entity.Add(entity);
		_context.SaveChanges();
		return entity;
	}

	public async Task<TEntity> AddAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties)
	{
		await _entity.AddAsync(entity);

		foreach (var includeProperty in includeProperties)
		{
			await _context.Entry(entity)
				.Reference(includeProperty)
				.LoadAsync();
		}

		await _context.SaveChangesAsync();
		return entity;
	}

	public IList<TEntity> AddRange(IList<TEntity> entities)
	{
		_context.AddRangeAsync(entities);
		_context.SaveChangesAsync();
		return entities;
	}

	public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
	{
		await _entity.AddRangeAsync(entities);
		await _context.SaveChangesAsync();
		return entities;
	}

	public bool Any(Expression<Func<TEntity, bool>> predicate)
	{
		return _entity.Any(predicate);
	}

	public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
	{
		return await _entity.AnyAsync(predicate, cancellationToken);
	}

	public TEntity Delete(TEntity entity)
	{
		_entity.Remove(entity);
		_context.SaveChanges();
		return entity;
	}

	public async Task<TEntity> DeleteAsync(TEntity entity)
	{
		await Task.Run(() =>
		{
			_entity.Remove(entity);
			_context.SaveChangesAsync();
		});
		return entity;
	}

	public IList<TEntity> DeleteRange(IList<TEntity> entities)
	{
		_entity.RemoveRange(entities);
		_context.SaveChanges();
		return entities;
	}

	public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities)
	{
		await Task.Run(() =>
		{
			_entity.RemoveRange(entities);
			_context.SaveChangesAsync();
		});
		return entities;
	}

	public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
	{
		IQueryable<TEntity> queryable = Query();
		if (!enableTracking)
			queryable = queryable.AsNoTracking();
		if (include != null)
			queryable = include(queryable);
		return queryable.FirstOrDefault(predicate);
	}

	public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false, CancellationToken cancellationToken = default)
	{
		IQueryable<TEntity> queryable = Query();
		if (!enableTracking)
			queryable = queryable.AsNoTracking();
		if (include != null)
			queryable = include(queryable);
		return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
	}


	public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
	{
		IQueryable<TEntity> queryable = Query();
		if (!enableTracking)
			queryable = queryable.AsNoTracking();
		if (include != null)
			queryable = include(queryable);
		if (predicate != null)
			queryable = queryable.Where(predicate);
		if (orderBy != null)
			return orderBy(queryable);
		return queryable;
	}

	public async Task<IPaginatedList<TEntity>> GetListByPaginatedAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 1, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
	{
		IQueryable<TEntity> query = _entity;

		// Takip etme ayarını kontrol et
		if (!enableTracking)
			query = query.AsNoTracking();

		// İstenilen entity'leri içe aktar
		if (include != null)
			query = include(query);

		// Filtreleme ifadesini uygula
		if (predicate != null)
			query = query.Where(predicate);

		// Sıralama ifadesini uygula
		if (orderBy != null)
			query = orderBy(query);

		// Sayfalama işlemi
		return PaginatedList<TEntity>.Create(query, index, size);
	}

	public IQueryable<TEntity> Query() => _entity;


	public TEntity Update(TEntity entity)
	{
		_entity.Update(entity);
		_context.SaveChanges();
		return entity;
	}

	public async Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includeProperties)
	{

		await Task.Run(() =>
		{
			_entity.Update(entity);

			foreach (var includeProperty in includeProperties)
			{
				_context.Entry(entity)
				.Reference(includeProperty)
				.LoadAsync();
			}
			_context.SaveChangesAsync();
		});
		return entity;
	}

	public IList<TEntity> UpdateRange(IList<TEntity> entities)
	{
		_entity.UpdateRange(entities);
		_context.SaveChanges();
		return entities;
	}

	public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
	{
		await Task.Run(() =>
		{
			_entity.UpdateRange(entities);
			_context.SaveChanges();
		});
		return entities;
	}

	public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false, CancellationToken cancellationToken = default)
	{

		IQueryable<TEntity> query = _entity;

		// Takip etme ayarını kontrol et
		if (!enableTracking)
			query = query.AsNoTracking();

		// İstenilen entity'leri içe aktar
		if (include != null)
			query = include(query);

		// Filtreleme ifadesini uygula
		if (predicate != null)
			query = query.Where(predicate);

		// Sıralama ifadesini uygula
		if (orderBy != null)
			query = orderBy(query);

		return query;
	}
}
