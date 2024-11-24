namespace vigilant_umbrella.Controllers.V1;

using Microsoft.AspNetCore.Mvc;
using vigilant_umbrella_application.Services.V1.Cities;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Defines the <see cref="CitiesController" />.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
/// <seealso cref="ControllerBase" />
/// <remarks>
/// Initializes a new instance of the <see cref="CitiesController" /> class.
/// </remarks>
/// <param name="logger">The logger.</param>
/// <param name="citiesAppServices">The cities application services.</param>
[ApiController]
[Route("[controller]")]
public class CitiesController(ICitiesAppServices citiesAppServices) : ControllerBase
{
    /// <summary>
    /// The cities application services
    /// </summary>
    private readonly ICitiesAppServices citiesAppServices = citiesAppServices;

    /// <summary>
    /// Gets a list of cities based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the criteria for retrieving cities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of cities.</returns>
    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] GetCitiesRequest request)
    {
        var response = await citiesAppServices.Get(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Gets a single city by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the city.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var response = await citiesAppServices.GetSingle(id).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Creates a new city based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the details of the city to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPost()]
    public async Task<IActionResult> Post(PostCityRequest request)
    {
        var response = await citiesAppServices.Post(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Updates an existing city with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the city to update.</param>
    /// <param name="request">The request containing the updated details of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, PutCityRequest request)
    {
        var response = await citiesAppServices.Put(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Partially updates an existing city with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the city to update.</param>
    /// <param name="request">The request containing the partial updates for the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, PatchCityRequest request)
    {
        var response = await citiesAppServices.Patch(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Deletes a city with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the city to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await citiesAppServices.Delete(id).ConfigureAwait(false);
        return Ok(response);
    }
}
