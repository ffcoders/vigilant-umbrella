namespace vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Defines the <see cref="GetCountriesRequest"/>.
/// </summary>
public class GetCountriesRequest
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the country code.
    /// </summary>
    /// <value>
    /// The country code.
    /// </value>
    public string? CountryCode { get; set; }
}
