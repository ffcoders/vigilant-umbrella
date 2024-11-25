using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
/// <remarks>
/// Initializes a new instance of the <see cref="CountriesAppServices"/> class.
/// </remarks>
/// <param name="uow">The unit of work.</param>
/// <param name="mapper">The mapper.</param>
public class CountriesAppServices(IUnitOfWork uow, IMapper mapper) : BaseAppServices(uow, mapper), ICountriesAppServices
{
    /// <inheritdoc />
    public async Task<List<Country>> Get(GetCountriesRequest request)
    {
        await new GetCountriesRequestValidator().ValidateAsync(request);

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
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        var country = await base.UnitOfWork.Countries.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

        return this.Mapper.Map<Country>(country);
    }

    /// <inheritdoc />
    public async Task<Result> Post(PostCountryRequest request)
    {
        await new PostCountryRequestValidator().ValidateAsync(request);

        var country = new vigilant_umbrella_domain.Entities.Countries.Country { Id = Guid.NewGuid(), Code = request.Code };

        _ = await base.UnitOfWork.Countries.Add(country);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Put(Guid id, PutCountryRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        await new PutCountryRequestValidator().ValidateAsync(request);

        var country = await base.UnitOfWork.Countries.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

        country.Code = request.Code;
        _ = base.UnitOfWork.Countries.Update(country);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }

    /// <inheritdoc />
    public async Task<Result> Patch(Guid id, PatchCountryRequest request)
    {
        if (id == Guid.Empty)
        {
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        await new PatchCountryRequestValidator().ValidateAsync(request);

        var country = await base.UnitOfWork.Countries.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

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
            throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.BadRequestException);
        }

        var country = await base.UnitOfWork.Countries.GetById(id) ?? throw new VigilantUmbrellaException(VigilantUmbrellaExceptionType.NotFoundException);

        _ = await base.UnitOfWork.Countries.Delete(country.Id);

        _ = await base.UnitOfWork.CompleteAsync();

        return new Result { Success = true };
    }
}
