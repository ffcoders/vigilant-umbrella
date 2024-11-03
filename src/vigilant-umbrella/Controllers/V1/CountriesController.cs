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
    public async Task<List<Country>> Get([FromQuery] GetRequest request)
    {
        return await countriesAppServices.Get(request).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    [HttpGet("{id}")]
    public async Task<Country> GetSingle(Guid id)
    {
        return await countriesAppServices.GetSingle(id).ConfigureAwait(false);
    }

    /// <summary>
    /// Posts the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<Result> Post(PostRequest request)
    {
        return await countriesAppServices.Post(request).ConfigureAwait(false);
    }

    /// <summary>
    /// Puts the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<Result> Put(Guid id, PutRequest request)
    {
        return await countriesAppServices.Put(id, request).ConfigureAwait(false);
    }

    /// <summary>
    /// Patches the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public async Task<Result> Patch(Guid id, PatchRequest request)
    {
        return await countriesAppServices.Patch(id, request).ConfigureAwait(false);
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<Result> Delete(Guid id)
    {
        return await countriesAppServices.Delete(id).ConfigureAwait(false);
    }
}
