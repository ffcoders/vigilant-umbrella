using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace vigilant_umbrella_infrastructure.Context;

/// <summary>
/// Defines the <see cref="VigilantUmbrellaDbContext" />.
/// </summary>
/// <seealso cref="System.IDisposable" />
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public interface IVigilantUmbrellaDbContext : IDisposable
{
    /// <summary>
    /// Entries the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    EntityEntry Entry(object entity);

    /// <summary>
    /// Sets this instance.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <returns></returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    /// <summary>
    /// Saves the changes asynchronous.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
