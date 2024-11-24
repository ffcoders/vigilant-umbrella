using vigilant_umbrella_application.Dtos;
using vigilant_umbrella_application.Dtos.V1.Cities;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

namespace vigilant_umbrella_application.Services.V1.Cities;

/// <summary>
/// Defines the <see cref="ICitiesAppServices" />.
/// </summary>
public interface ICitiesAppServices
{
    /// <summary>
    /// Gets a single city by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the city.</returns>
    Task<City> GetSingle(Guid id);

    /// <summary>
    /// Gets a list of cities based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the criteria for retrieving cities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of cities.</returns>
    Task<List<City>> Get(GetCitiesRequest request);

    /// <summary>
    /// Creates a new city based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the details of the city to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Post(PostCityRequest request);

    /// <summary>
    /// Updates an existing city with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the city to update.</param>
    /// <param name="request">The request containing the updated details of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Put(Guid id, PutCityRequest request);

    /// <summary>
    /// Partially updates an existing city with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the city to update.</param>
    /// <param name="request">The request containing the partial updates for the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Patch(Guid id, PatchCityRequest request);

    /// <summary>
    /// Deletes a city with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the city to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Delete(Guid id);
}
