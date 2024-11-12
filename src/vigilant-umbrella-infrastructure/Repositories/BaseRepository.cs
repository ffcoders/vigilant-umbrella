using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using vigilant_umbrella_infrastructure.Context;

namespace vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Defines the basic CRUD operations for a repository.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public class BaseRepository<TEntity>(IVigilantUmbrellaDbContext context) where TEntity : class
{
    internal IVigilantUmbrellaDbContext context = context;
    internal DbSet<TEntity> dbSet = context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> Get(
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

    public async Task<TEntity> GetByID(object id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Entity not found");
        }

        return entity;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        var entityEntry = await dbSet.AddAsync(entity);
        return entityEntry.Entity;
    }

    public async Task Delete(object id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Entity not found");
        }

        var propertyInfo = typeof(TEntity).GetProperty("IsDeleted");
        if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
        {
            propertyInfo.SetValue(entity, true);
        }
    }

    public void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}