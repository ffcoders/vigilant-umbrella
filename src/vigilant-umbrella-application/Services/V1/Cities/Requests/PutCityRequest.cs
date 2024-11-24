namespace vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Represents a request to update a city with a specific code.
/// </summary>
public class PutCityRequest
{
    /// <summary>
    /// Gets or sets the code of the city to be updated.
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Gets or sets the name of the city to be updated.
    /// </summary>
    public required string Name { get; set; }
}
