using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;
using vigilant_umbrella_domain.Exceptions;
using vigilant_umbrella_infrastructure.Context;

namespace vigilant_umbrella_application.Services.V1.Countries;

public class CountriesAppServices : ICountriesAppServices
{
    private readonly VigilantUmbrellaDbContext vigilantUmbrellaDbContext;

    private readonly IMapper mapper;

    public CountriesAppServices(VigilantUmbrellaDbContext vigilantUmbrellaDbContext, IMapper mapper)
    {
        this.vigilantUmbrellaDbContext = vigilantUmbrellaDbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<Country> GetSingle(Guid id)
    {
        var result = await vigilantUmbrellaDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);

        return mapper.Map<Country>(result);
    }

    /// <inheritdoc />
    public async Task<List<Country>> Get(GetRequest request)
    {
        var result = await vigilantUmbrellaDbContext.Countries
                                                    .Where(x => string.IsNullOrEmpty(x.Code) || x.Code == request.Code)
                                                    .ToListAsync();

        return mapper.Map<List<Country>>(result);
    }

    /// <inheritdoc />
    public async Task<Result> Post(PostRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<Result> Put(Guid id, PutRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<Result> Patch(Guid id, PatchRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<Result> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
