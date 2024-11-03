using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

namespace vigilant_umbrella_application.Services.V1.Countries;

/// <summary>
/// Defines the <see cref="ICountriesAppServices" />.
/// </summary>
public interface ICountriesAppServices
{
    /// <summary>
    /// Gets the single.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Country> GetSingle(Guid id);

    /// <summary>
    /// Gets the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<List<Country>> Get(GetRequest request);

    /// <summary>
    /// Posts the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<Result> Post(PostRequest request);

    /// <summary>
    /// Puts the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<Result> Put(Guid id, PutRequest request);

    /// <summary>
    /// Patches the specified request.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    Task<Result> Patch(Guid id, PatchRequest request);

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result> Delete(Guid id);
}
