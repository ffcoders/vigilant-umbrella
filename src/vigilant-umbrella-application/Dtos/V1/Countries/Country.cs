namespace vigilant_umbrella_application.Dtos.V1.Countries;

/// <summary>
/// Defines the <see cref="Country" />.
/// </summary>
/// <seealso cref="vigilant_umbrella_application.Dtos.BaseDto" />
public class Country : BaseDto
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the population.
    /// </summary>
    /// <value>
    /// The population.
    /// </value>
    public required int Population { get; set; }

    /// <summary>
    /// Gets or sets the cities.
    /// </summary>
    /// <value>
    /// The cities.
    /// </value>
    public IEnumerable<vigilant_umbrella_domain.Entities.Cities.City> Cities { get; set; }
}
