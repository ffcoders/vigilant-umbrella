namespace vigilant_umbrella_infrastructure.UnitOfWork;

using vigilant_umbrella_domain.Entities.Countries;
using vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Represents the base unit of work interface that defines methods for saving and disposing resources.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the repository for managing <see cref="Country"/> entities.
    /// </summary>
    BaseRepository<Country> Countries { get; }

    /// <summary>
    /// Asynchronously saves all changes made in this unit of work.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}
