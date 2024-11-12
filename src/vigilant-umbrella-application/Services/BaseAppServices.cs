namespace vigilant_umbrella_application.Services;

using AutoMapper;
using vigilant_umbrella_infrastructure.UnitOfWork;

/// <summary>
/// Defines the <see cref="BaseAppServices" /> class.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BaseAppServices"/> class.
/// </remarks>
/// <param name="unitOfWork">The unit of work.</param>
/// <param name="mapper">The mapper.</param>
public class BaseAppServices(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    /// Gets the unit of work.
    /// </summary>
    /// <value>The unit of work instance.</value>
    public IUnitOfWork UnitOfWork
    {
        get
        {
            return this.PrivateUnitOfWork;
        }
    }

    /// <summary>
    /// Gets the mapper.
    /// </summary>
    /// <value>The mapper instance.</value>
    public IMapper Mapper
    {
        get
        {
            return this.PrivateMapper;
        }
    }

    private IUnitOfWork PrivateUnitOfWork { get; } = unitOfWork;

    private IMapper PrivateMapper { get; set; } = mapper;
}
