namespace vigilant_umbrella_infrastructure.Context;

using Microsoft.EntityFrameworkCore;
using vigilant_umbrella_domain.Entities.Countries;

/// <summary>
/// Defines the <see cref="VigilantUmbrellaDbContext"/>.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class VigilantUmbrellaDbContext(DbContextOptions<VigilantUmbrellaDbContext> options) : DbContext(options), IVigilantUmbrellaDbContext
{
    /// <summary>
    /// Gets or sets the countries.
    /// </summary>
    /// <value>
    /// The countries.
    /// </value>
    public DbSet<Country> Countries { get; set; } = null!;

    /// <summary>
    /// Gets or sets the cities.
    /// </summary>
    public DbSet<City> Cities { get; set; } = null!;

    /// <summary>
    /// Override this method to configure the database (and other options) to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// The base implementation does nothing.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
    /// typically define extension methods on this object that allow you to configure the context.</param>
    /// <remarks>
    /// <para>
    /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
    /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    /// the options have already been set, and skip some or all of the logic in
    /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information and examples.
    /// </para>
    /// </remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
