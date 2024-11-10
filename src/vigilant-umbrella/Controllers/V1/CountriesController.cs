using Microsoft.AspNetCore.Mvc;
using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

namespace vigilant_umbrella.Controllers.V1;

/// <summary>
/// Defines the <see cref="CountriesController" />.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    /// <summary>
    /// The countries application services
    /// </summary>
    private readonly ICountriesAppServices countriesAppServices;

    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<CountriesController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CountriesController" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="countriesAppServices">The countries application services.</param>
    public CountriesController(ILogger<CountriesController> logger, ICountriesAppServices countriesAppServices)
    {
        _logger = logger;
        this.countriesAppServices = countriesAppServices;
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery] GetRequest request)
    {
        var response = await countriesAppServices.Get(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var response = await countriesAppServices.GetSingle(id).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Posts the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> Post(PostRequest request)
    {
        var response = await countriesAppServices.Post(request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Puts the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, PutRequest request)
    {
        var response = await countriesAppServices.Put(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Patches the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, PatchRequest request)
    {
        var response = await countriesAppServices.Patch(id, request).ConfigureAwait(false);
        return Ok(response);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await countriesAppServices.Delete(id).ConfigureAwait(false);
        return Ok(response);
    }
}
