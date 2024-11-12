namespace vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Represents a request to patch a country's information.
/// </summary>
public class PatchRequest
{
    /// <summary>
    /// Gets or sets the fields to update in the patch request.
    /// </summary>
    public required string FieldsToUpdate { get; set; }

    /// <summary>
    /// Gets or sets the code of the country to be patched.
    /// </summary>
    public string? Code { get; set; }
}
