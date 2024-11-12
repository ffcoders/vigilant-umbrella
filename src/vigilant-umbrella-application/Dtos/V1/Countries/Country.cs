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
}
