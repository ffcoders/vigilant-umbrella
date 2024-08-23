namespace vigilant_umbrella_application.Dtos;

/// <summary>
/// Defines the <see cref="BaseTypedDto"/>.
/// </summary>
public class BaseTypedDto
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }
}
