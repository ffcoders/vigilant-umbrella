using AutoMapper;
using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;
using vigilant_umbrella_application.Services.V1.Countries.Validation;
using vigilant_umbrella_domain.Exceptions;
using vigilant_umbrella_infrastructure.UnitOfWork;

namespace vigilant_umbrella_application.Services.V1.Countries;

/// <summary>
/// Provides services for managing countries.
/// </summary>
public class CountriesAppServices : BaseAppServices, ICountriesAppServices
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CountriesAppServices"/> class.
    /// </summary>
    /// <param name="uow">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public CountriesAppServices(IUnitOfWork uow, IMapper mapper)
        : base(uow, mapper)
    {
    }

    /// <inheritdoc />
    public async Task<List<Country>> Get(GetRequest request)
    {
        await new GetRequestValidator().ValidateAsync(request);

        var countries = await base.UnitOfWork.Countries.Get(
            filter: c => (string.IsNullOrEmpty(request.Code) || c.Code == request.Code),
            orderBy: q => q.OrderBy(c => c.Code)
        );

        return this.Mapper.Map<List<Country>>(countries);
    }

    /// <inheritdoc />
    public async Task<Country> GetSingle(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid country id.", nameof(id));
        }

        var country = await base.UnitOfWork.Countries.GetById(id);

        if (country == null)
        {
            throw new NotFoundException("Country not found.");
        }

        return this.Mapper.Map<Country>(country);
    }

    /// <inheritdoc />
    public async Task<Result> Post(PostRequest request)
    {
        await new PostRequestValidator().ValidateAsync(request);

        var country = new vigilant_umbrella_domain.Entities.Countries.Country { Id = Guid.NewGuid(), Code = request.Code };

        _ = await base.UnitOfWork.Countries.Add(country);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Put(Guid id, PutRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid country id.", nameof(id));
        }

        await new PutRequestValidator().ValidateAsync(request);

        var country = await base.UnitOfWork.Countries.GetById(id);
        if (country == null)
        {
            throw new NotFoundException("Country not found.");
        }

        country.Code = request.Code;
        _ = base.UnitOfWork.Countries.Update(country);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Patch(Guid id, PatchRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid country id.", nameof(id));
        }

        await new PatchRequestValidator().ValidateAsync(request);

        var country = await base.UnitOfWork.Countries.GetById(id);
        if (country == null)
        {
            throw new NotFoundException("Country not found.");
        }

        if (request.FieldsToUpdate.Contains("Code"))
        {
            country.Code = request.Code!;
        }

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Invalid country id.", nameof(id));
        }

        var country = await base.UnitOfWork.Countries.GetById(id);
        if (country == null)
        {
            throw new NotFoundException("Country not found.");
        }

        _ = await base.UnitOfWork.Countries.Delete(id);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }
}
