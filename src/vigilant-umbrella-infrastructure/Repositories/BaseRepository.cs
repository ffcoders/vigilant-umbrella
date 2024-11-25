using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using vigilant_umbrella_domain.Exceptions;
using vigilant_umbrella_infrastructure.Context;

namespace vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Defines the basic CRUD operations for a repository.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public class BaseRepository<TEntity>(IVigilantUmbrellaDbContext context) : IBaseRepository<TEntity> where TEntity : class 
{
    internal IVigilantUmbrellaDbContext context = context;
    internal DbSet<TEntity> dbSet = context.Set<TEntity>();

    /// <inheritdoc/>
    public IQueryable<TEntity> Query()
    {
        return dbSet;
    }

    /// <inheritdoc/>
    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity> GetById(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);
        }

        return entity;
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var createdAtInfo = typeof(TEntity).GetProperty("CreatedAt");
        if (createdAtInfo != null && createdAtInfo.PropertyType == typeof(DateTime))
        {
            createdAtInfo.SetValue(entity, DateTime.UtcNow);
        }

        var updatedAtInfo = typeof(TEntity).GetProperty("UpdatedAt");
        if (updatedAtInfo != null && updatedAtInfo.PropertyType == typeof(DateTime))
        {
            updatedAtInfo.SetValue(entity, DateTime.UtcNow);
        }

        var isDeletedAtInfo = typeof(TEntity).GetProperty("IsDeleted");
        if (isDeletedAtInfo != null && isDeletedAtInfo.PropertyType == typeof(bool))
        {
            isDeletedAtInfo.SetValue(entity, false);
        }

        var entityEntry = await dbSet.AddAsync(entity);
        return entityEntry.Entity;
    }

    /// <inheritdoc/>
    public virtual TEntity Update(TEntity entity)
    {
        var propertyInfo = typeof(TEntity).GetProperty("UpdatedAt");
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(DateTime))
        {
            propertyInfo.SetValue(entity, DateTime.UtcNow);
        }
        
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    /// <inheritdoc/>
    public virtual async Task<TEntity> Delete(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);
        }

        var isDeletedAtInfo = typeof(TEntity).GetProperty("IsDeleted");
        if (isDeletedAtInfo != null && isDeletedAtInfo.PropertyType == typeof(bool))
        {
            isDeletedAtInfo.SetValue(entity, true);
        }

        var updatedAtInfo = typeof(TEntity).GetProperty("UpdatedAt");
        if (updatedAtInfo != null && updatedAtInfo.PropertyType == typeof(DateTime))
        {
            updatedAtInfo.SetValue(entity, DateTime.UtcNow);
        }

        return entity;
    }
}