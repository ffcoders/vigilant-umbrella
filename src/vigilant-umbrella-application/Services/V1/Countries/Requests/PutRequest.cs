namespace vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Represents a request to update a country with a specific code.
/// </summary>
public class PutRequest
{
    /// <summary>
    /// Gets or sets the code of the country to be updated.
    /// </summary>
    public required string Code { get; set; }
}
