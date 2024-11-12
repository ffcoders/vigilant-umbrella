namespace vigilant_umbrella_infrastructure.UnitOfWork;

using vigilant_umbrella_domain.Entities.Countries;
using vigilant_umbrella_infrastructure.Context;
using vigilant_umbrella_infrastructure.Repositories;

/// <summary>
/// Represents the base unit of work interface that defines methods for saving and disposing resources.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class UnitOfWork(IVigilantUmbrellaDbContext context) : IUnitOfWork, IAsyncDisposable, IDisposable
{
    private readonly IVigilantUmbrellaDbContext _context = context;
    private BaseRepository<Country>? _countries;
    private bool _disposed = false;

    /// <summary>
    /// Gets the repository for managing <see cref="Country"/> entities.
    /// </summary>
    public BaseRepository<Country> Countries
    {
        get
        {
            return _countries ??= new BaseRepository<Country>(_context);
        }
    }

    /// <summary>
    /// Saves all changes made in this context to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="UnitOfWork"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">A boolean value indicating whether to release both managed and unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    /// <summary>
    /// Releases all resources used by the <see cref="UnitOfWork"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Asynchronously releases all resources used by the <see cref="UnitOfWork"/>.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(false);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Asynchronously releases the unmanaged resources used by the <see cref="UnitOfWork"/> and optionally releases the managed resources.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_context is IAsyncDisposable asyncDisposable)
        {
            await asyncDisposable.DisposeAsync();
        }
        else
        {
            _context.Dispose();
        }
    }
}
