namespace vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Represents a request to create a new country entry.
/// </summary>
public class PostRequest
{
    /// <summary>
    /// Gets or sets the code of the country.
    /// </summary>
    public required string Code { get; set; }
}
