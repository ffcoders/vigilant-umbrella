namespace vigilant_umbrella.Controllers.V1;

using Microsoft.AspNetCore.Mvc;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Defines the <see cref="CountriesController" />.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
/// <seealso cref="ControllerBase" />
/// <remarks>
/// Initializes a new instance of the <see cref="CountriesController" /> class.
/// </remarks>
/// <param name="logger">The logger.</param>
/// <param name="countriesAppServices">The countries application services.</param>
[ApiController]
[Route("[controller]")]
public class CountriesController(ICountriesAppServices countriesAppServices) : ControllerBase
{
    /// <summary>
    /// The countries application services
    /// </summary>
    private readonly ICountriesAppServices countriesAppServices = countriesAppServices;

    /// <summary>
    /// Gets a list of countries based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the criteria for retrieving countries.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of countries.</returns>
    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] GetCountriesRequest request)
    {
        var response = await countriesAppServices.Get(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Gets a single country by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the country.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var response = await countriesAppServices.GetSingle(id).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Creates a new country based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the details of the country to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPost()]
    public async Task<IActionResult> Post(PostCountryRequest request)
    {
        var response = await countriesAppServices.Post(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Updates an existing country with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the country to update.</param>
    /// <param name="request">The request containing the updated details of the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, PutCountryRequest request)
    {
        var response = await countriesAppServices.Put(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Partially updates an existing country with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the country to update.</param>
    /// <param name="request">The request containing the partial updates for the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, PatchCountryRequest request)
    {
        var response = await countriesAppServices.Patch(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Deletes a country with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the country to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await countriesAppServices.Delete(id).ConfigureAwait(false);
        return Ok(response);
    }
}
