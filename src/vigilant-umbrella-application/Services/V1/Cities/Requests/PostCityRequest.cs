namespace vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Represents a request to create a new city entry.
/// </summary>
public class PostCityRequest
{
    /// <summary>
    /// Gets or sets the code of the city.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Gets or sets the name of the city.
    /// </summary>
    public required string Name { get; set; }
}
