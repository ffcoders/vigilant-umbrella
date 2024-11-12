using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using vigilant_umbrella_domain.Entities.Countries;
using vigilant_umbrella_infrastructure.Context;

namespace vigilant_umbrella_infrastructure.Repositories.Countries;

public class CountriesRepository : BaseRepository<Country>
{
    public CountriesRepository(VigilantUmbrellaDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Country>> Get(Expression<Func<Country, bool>> filter)
    {
        return await base.Get(filter: filter); // TODO: Implementar forma do order by. Desse jeito funciona mas está muito repassar o valores
    }

    public async Task<Country> GetById(Guid id)
    {
        var entity = await base.GetByID(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Country not found");
        }
        return entity;
    }

    public async Task<Country> Add(Country entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        await base.Add(entity);

        return entity;
    }

    public Country Update(Country entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;

        base.Update(entity);

        return entity;
    }

    public async Task Delete(Guid id)
    {
        await base.Delete(id);
    }
}
