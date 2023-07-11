using LinqKit;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using OnlineTutoringPlatformPrototype.Data.Repositories.Interfaces;
using OnlineTutoringPlatformPrototype.Models.BaseClasses;

using System.Diagnostics;
using System.Linq.Expressions;

namespace OnlineTutoringPlatformPrototype.Data.Repositories.Implementation
{
	/// <summary>
	/// Implementation of <see cref="IRepository{TEntity}"/>
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
	{
		#region Private Variables

		private readonly OTPDbContext _context;

		#endregion

		#region Constructor

		/// <summary>
		/// Public constructor
		/// </summary>
		/// <param name="context"></param>
		public Repository(OTPDbContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Add new entity to the repository
		/// </summary>
		/// <param name="entity"></param>
		public async Task AddAsync(TEntity entity)
		{
			entity.CreatedDate = DateTime.UtcNow;

			entity.ModifiedDate = DateTime.UtcNow;

			entity.IsDeleted = false;

			await _context.Set<TEntity>().AddAsync(entity);
		}

		/// <summary>
		/// Marks TEntity object as 'Updated' so that EF can update it in the database
		/// </summary>
		/// <param name="entity"></param>
		public Task UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;

			entity.ModifiedDate = DateTime.UtcNow;

			return Task.CompletedTask;
		}

		/// <summary>
		/// Delete specified entity of type T from the repository
		/// </summary>
		/// <param name="entity"></param>
		public Task DeleteAsync(TEntity entity)
		{
			if(entity == null)
			{
				Debug.Assert(false, "Trying to delete a null entity");
			}

			_context.Set<TEntity>().Remove(entity);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Retrieves TEntity object based on the provided filter (criteria) and includes any dependent entities
		/// if specified
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<TEntity> GetAsync(ExpressionStarter<TEntity> filter, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();

			if(includes != null && includes.Length > 0)
			{
				foreach(var include in includes)
				{
					query = query.Include(include);
				}
			}

			TEntity entity = await query.FirstOrDefaultAsync(filter);

			return entity;
		}

		/// <summary>
		/// Retrieves collection of TEntity objects based on the provided filter (criteria) and includes any dependent
		/// entities, orders them by the criteria, if specified. This method also supports paging and returns total
		/// number of records retrieved by the specified criteria
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="totalRecordsCount"></param>
		/// <param name="orderBy"></param>
		/// <param name="skipRange"></param>
		/// <param name="requiredRange"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<Tuple<IEnumerable<TEntity>, int>> GetAllAsync(ExpressionStarter<TEntity> filter, int totalRecordsCount,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skipRange = null, int? requiredRange = null,
			params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();

			if(filter != null)
			{
				totalRecordsCount = query.Where(filter).Count();

				if(skipRange.HasValue && requiredRange.HasValue)
				{
					query = query.Where(filter).Skip(skipRange.Value).Take(requiredRange.Value);
				}
				else
				{
					query = query.Where(filter);
				}
			}

			if(includes != null && includes.Length > 0)
			{
				foreach(var include in includes)
				{
					query = query.Include(include);
				}
			}

			if(orderBy != null)
			{
				query = orderBy(query);
			}

			var entities = await query.ToListAsync();

			var tuple = new Tuple<IEnumerable<TEntity>, int>(entities, totalRecordsCount);

			return tuple;
		}

		/// <summary>
		/// Retrieves collection of TEntity objects based on the provided filter (criteria)
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="includes"></param>
		/// <returns></returns>
		public async Task<IEnumerable<TEntity>> GetAllAsync(ExpressionStarter<TEntity> filter, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>().Where(filter);

			if(includes != null && includes.Length > 0)
			{
				foreach(var include in includes)
				{
					query = query.Include(include);
				}
			}

			return await query.ToListAsync();
		}

		/// <summary>
		/// Commits changes to the repository asynchronously
		/// </summary>
		/// <returns></returns>
		public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
			=> await _context.SaveChangesAsync(cancellationToken);

		/// <summary>
		/// Starts the transaction
		/// </summary>
		/// <returns></returns>
		public async Task<IDbContextTransaction> StartTransaction()
		{
			return await _context.Database.BeginTransactionAsync();
		}

		#endregion


	}
}
