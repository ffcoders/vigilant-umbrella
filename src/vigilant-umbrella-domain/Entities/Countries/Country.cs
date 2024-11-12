using System.ComponentModel.DataAnnotations;

namespace vigilant_umbrella_domain.Entities.Countries;

/// <summary>
/// Defines the table <see cref="Country"/>.
/// </summary>
/// <seealso cref="vigilant_umbrella_domain.Entities.BaseEntity" />
public class Country : BaseEntity
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }
}
