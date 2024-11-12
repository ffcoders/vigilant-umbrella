namespace vigilant_umbrella_infrastructure.UnitOfWork;

/// <summary>
/// Represents the base unit of work interface that defines methods for saving and disposing resources.
/// </summary>
public interface IBaseUnitOfWork
{
    /// <summary>
    /// Saves all changes made in the unit of work.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveAsync();

    /// <summary>
    /// Disposes the resources used by the unit of work.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    Task DisposeAsync();
}
