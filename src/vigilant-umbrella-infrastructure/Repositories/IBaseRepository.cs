using System.Linq.Expressions;

namespace vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Defines the basic CRUD operations for a repository.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Gets all entities as an IQueryable.
    /// </summary>
    /// <returns>An IQueryable of entities.</returns>
    IQueryable<TEntity> Query();

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <param name="filter">An optional filter to apply to the entities.</param>
    /// <param name="orderBy">An optional function to order the entities.</param>
    /// <param name="includeProperties">A comma-separated list of related entities to include in the query.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
    public abstract Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    /// <summary>
    /// Gets a single entity or the default value if no entity is found.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity or the default value.</returns>
    public abstract Task<TEntity> GetById(Guid id);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
    public abstract Task<TEntity> Add(TEntity entity);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    public abstract TEntity Update(TEntity entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity.</returns>
    public abstract Task<TEntity> Delete(Guid id);
}
