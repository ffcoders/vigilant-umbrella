//namespace vigilant_umbrella_domain.Repositories;

///// <summary>
///// Defines the basic CRUD operations for a repository.
///// </summary>
///// <typeparam name="T">The type of the entity.</typeparam>
//public interface IBaseRepository<T>
//{
//    /// <summary>
//    /// Gets all entities.
//    /// </summary>
//    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
//    public abstract Task<IEnumerable<T>> Get();

//    /// <summary>
//    /// Gets a single entity or the default value if no entity is found.
//    /// </summary>
//    /// <returns>A task that represents the asynchronous operation. The task result contains the entity or the default value.</returns>
//    public abstract Task<T> GetById(Guid id);

//    /// <summary>
//    /// Adds a new entity.
//    /// </summary>
//    /// <param name="entity">The entity to add.</param>
//    /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
//    public abstract Task<T> Add(T entity);

//    /// <summary>
//    /// Updates an existing entity.
//    /// </summary>
//    /// <param name="newEntity">The new entity values.</param>
//    /// <param name="oldEntity">The old entity values.</param>
//    /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity.</returns>
//    public abstract Task<T> Update(T newEntity, T oldEntity);

//    /// <summary>
//    /// Deletes an entity.
//    /// </summary>
//    /// <param name="entity">The entity to delete.</param>
//    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted entity.</returns>
//    public abstract Task<T> Delete(T entity);
//}
