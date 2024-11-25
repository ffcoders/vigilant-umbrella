using AutoMapper;
using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Cities;
using vigilant_umbrella_application.Services.V1.Cities.Requests;
using vigilant_umbrella_application.Services.V1.Cities.Validation;
using vigilant_umbrella_domain.Exceptions;
using vigilant_umbrella_infrastructure.UnitOfWork;

namespace vigilant_umbrella_application.Services.V1.Cities;

/// <summary>
/// Provides services for managing cities.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CitiesAppServices"/> class.
/// </remarks>
/// <param name="uow">The unit of work.</param>
/// <param name="mapper">The mapper.</param>
public class CitiesAppServices(IUnitOfWork uow, IMapper mapper) : BaseAppServices(uow, mapper), ICitiesAppServices
{
    /// <inheritdoc />
    public async Task<List<City>> Get(GetCitiesRequest request)
    {
        await new GetCitiesRequestValidator().ValidateAsync(request);

        var cities = await base.UnitOfWork.Cities.Get(
            filter: c => ((string.IsNullOrEmpty(request.Code) || c.Code == request.Code)
                        && (string.IsNullOrEmpty(request.CountryCode) || c.Country.Code == request.CountryCode)),
            orderBy: q => q.OrderBy(c => c.Code)
        );

        return this.Mapper.Map<List<City>>(cities);
    }

    /// <inheritdoc />
    public async Task<City> GetSingle(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        var city = await base.UnitOfWork.Cities.GetById(id);

        return this.Mapper.Map<City>(city);
    }

    /// <inheritdoc />
    public async Task<Result> Post(PostCityRequest request)
    {
        await new PostCityRequestValidator().ValidateAsync(request);

        var city = new vigilant_umbrella_domain.Entities.Cities.City { Id = Guid.NewGuid(), Code = request.Code, Name = request.Name };

        _ = await base.UnitOfWork.Cities.Add(city);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Put(Guid id, PutCityRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        await new PutCityRequestValidator().ValidateAsync(request);

        var city = await base.UnitOfWork.Cities.GetById(id);

        city.Code = request.Code;
        city.Name = request.Name;
        _ = base.UnitOfWork.Cities.Update(city);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Patch(Guid id, PatchCityRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        await new PatchCityRequestValidator().ValidateAsync(request);

        var city = await base.UnitOfWork.Cities.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

        if (request.FieldsToUpdate.ToLower().Contains("code"))
        {
            city.Code = request.Code!;
        }

        if (request.FieldsToUpdate.ToLower().Contains("name"))
        {
            city.Name = request.Name!;
        }

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        var city = await base.UnitOfWork.Cities.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

        _ = await base.UnitOfWork.Cities.Delete(city.Id);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }
}
