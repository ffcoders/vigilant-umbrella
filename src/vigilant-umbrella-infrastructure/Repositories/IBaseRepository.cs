using System.Linq.Expressions;

namespace vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Defines the basic CRUD operations for a repository.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IBaseRepository<TEntity>
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
    public abstract Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null);

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
    /// <returns>The added entity.</returns>
    public abstract TEntity Add(TEntity entity);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="newEntity">The new entity values.</param>
    /// <param name="oldEntity">The old entity values.</param>
    /// <returns>The updated entity.</returns>
    public abstract TEntity Update(TEntity newEntity, TEntity oldEntity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>The deleted entity.</returns>
    public abstract TEntity Delete(TEntity entity);
}
