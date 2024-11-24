namespace vigilant_umbrella_application.Dtos.V1.Cities;

/// <summary>
/// Defines the <see cref="City" />.
/// </summary>
/// <seealso cref="vigilant_umbrella_application.Dtos.BaseDto" />
public class City : BaseDto
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }
}
