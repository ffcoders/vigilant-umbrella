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
    /// Gets a single country by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the country.</returns>
    Task<Country> GetSingle(Guid id);

    /// <summary>
    /// Gets a list of countries based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the criteria for retrieving countries.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of countries.</returns>
    Task<List<Country>> Get(GetCountriesRequest request);

    /// <summary>
    /// Creates a new country based on the specified request.
    /// </summary>
    /// <param name="request">The request containing the details of the country to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Post(PostCountryRequest request);

    /// <summary>
    /// Updates an existing country with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the country to update.</param>
    /// <param name="request">The request containing the updated details of the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Put(Guid id, PutCountryRequest request);

    /// <summary>
    /// Partially updates an existing country with the specified identifier based on the provided request.
    /// </summary>
    /// <param name="id">The identifier of the country to update.</param>
    /// <param name="request">The request containing the partial updates for the country.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Patch(Guid id, PatchCountryRequest request);

    /// <summary>
    /// Deletes a country with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the country to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the operation.</returns>
    Task<Result> Delete(Guid id);
}
