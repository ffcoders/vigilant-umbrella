namespace vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Represents a request to patch a cities information.
/// </summary>
public class PatchCityRequest
{
    /// <summary>
    /// Gets or sets the fields to update in the patch request.
    /// </summary>
    public required string FieldsToUpdate { get; set; }

    /// <summary>
    /// Gets or sets the code of the city to be patched.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the name of the city to be patched.
    /// </summary>
    public string? Name { get; set; }
}
