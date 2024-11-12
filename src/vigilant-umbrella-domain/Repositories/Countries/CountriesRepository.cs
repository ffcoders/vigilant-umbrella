//using vigilant_umbrella_domain.Entities.Countries;

//namespace vigilant_umbrella_domain.Repositories.Countries;

//public class CountriesRepository : ICountriesRepository
//{
//    private readonly IVigilantUmbrellaDbContext _context;

//    public CountriesRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<IEnumerable<Country>> Get()
//    {
//        return await _context.Countries.ToListAsync();
//    }

//    public async Task<Country> GetById(Guid id)
//    {
//        return await _context.Countries.FindAsync(id);
//    }

//    public async Task<Country> Add(Country entity)
//    {
//        _context.Countries.Add(entity);
//        await _context.SaveChangesAsync();
//        return entity;
//    }

//    public async Task<Country> Update(Country newEntity, Country oldEntity)
//    {
//        _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
//        await _context.SaveChangesAsync();
//        return newEntity;
//    }

//    public async Task<Country> Delete(Country entity)
//    {
//        _context.Countries.Remove(entity);
//        await _context.SaveChangesAsync();
//        return entity;
//    }
//}
