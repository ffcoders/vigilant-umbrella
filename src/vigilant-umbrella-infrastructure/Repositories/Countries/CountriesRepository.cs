namespace vigilant_umbrella_infrastructure.Repositories.Countries;

using System.Linq.Expressions;
using vigilant_umbrella_domain.Entities.Countries;
using vigilant_umbrella_infrastructure.Context;

public class CountriesRepository(IVigilantUmbrellaDbContext context) : BaseRepository<Country>(context)
{
    /// <inheritdoc/>
    public override async Task<IEnumerable<Country>> Get(Expression<Func<Country, bool>>? filter = null,
        Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null,
        string includeProperties = "")
    {
        return await base.Get(filter: filter, orderBy: orderBy, includeProperties: includeProperties);
    }

    /// <inheritdoc/>
    public override async Task<Country> GetById(Guid id)
    {
        var entity = await base.GetById(id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Country not found");
        }

        return entity;
    }

    /// <inheritdoc/>
    public override async Task<Country> Add(Country entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        await base.Add(entity);

        return entity;
    }

    /// <inheritdoc/>
    public override Country Update(Country entity)
    {
        base.Update(entity);

        return entity;
    }

    /// <inheritdoc/>
    public override async Task<Country> Delete(Guid id)
    {
        var entity = await base.Delete(id);
        return entity;
    }
}
