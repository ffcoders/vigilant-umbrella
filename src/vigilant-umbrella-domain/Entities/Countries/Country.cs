﻿namespace vigilant_umbrella_domain.Entities.Countries;

/// <summary>
/// Defines the table <see cref="Country"/>.
/// </summary>
/// <seealso cref="vigilant_umbrella_domain.Entities.BaseEntity" />
public class Country : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Country"/> class.
    /// </summary>
    public Country()
    {
        this.Cities = [];
    }

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }

    /// <summary>
    /// Gets or sets the cities.
    /// </summary>
    public IEnumerable<City> Cities { get; set; }
}
