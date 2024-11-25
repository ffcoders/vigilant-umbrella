using vigilant_umbrella_domain.Entities.Countries;

namespace vigilant_umbrella_domain.Entities.Cities;

/// <summary>
/// Defines the table <see cref="City"/>.
/// </summary>
/// <seealso cref="BaseEntity" />
public class City : BaseEntity
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }

    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public virtual Country Country { get; set; } = null!;
}
