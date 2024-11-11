using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using vigilant_umbrella.Controllers.V1;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

namespace vigilant_umbrella_test;

public class CountriesTest
{
    private readonly Mock<ICountriesAppServices> _mockService;
    private readonly Mock<ILogger<CountriesController>> _mockLogger;
    private readonly CountriesController _controller;

    public CountriesTest()
    {
        _mockService = new Mock<ICountriesAppServices>();
        _mockLogger = new Mock<ILogger<CountriesController>>();
        _controller = new CountriesController(_mockLogger.Object, _mockService.Object);
    }

    // ... other code ...

    [Fact]
    public async Task GetAllCountries_ReturnsOkResult()
    {
        // Arrange
        var countries = new List<vigilant_umbrella_application.Dtos.V1.Countries.Country>
        {
            new vigilant_umbrella_application.Dtos.V1.Countries.Country { Id = Guid.NewGuid(), Code = "CD" }
        };
        var request = new GetRequest(); // Create a GetRequest object
        _mockService.Setup(service => service.Get(request)).Returns(Task.FromResult(countries));

        // Act
        var result = await _controller.Get(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<vigilant_umbrella_application.Dtos.V1.Countries.Country>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task GetCountryById_ReturnsNotFoundResult()
    {
        // Arrange
        var countries = new vigilant_umbrella_application.Dtos.V1.Countries.Country();

        _mockService.Setup(service => service.GetSingle(Guid.NewGuid())).Returns(Task.FromResult(countries));

        // Act
        var result = await _controller.GetSingle(Guid.Empty);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Null(okResult.Value);
    }

    [Fact]
    public async Task GetCountryById_ReturnsOkResult()
    {
        // Arrange
        Guid countryId = Guid.NewGuid();
        var country = new vigilant_umbrella_application.Dtos.V1.Countries.Country { Id = countryId, Code = "CD" };
        _mockService.Setup(service => service.GetSingle(countryId)).Returns(Task.FromResult(country));

        // Act
        var result = await _controller.GetSingle(countryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<vigilant_umbrella_application.Dtos.V1.Countries.Country>(okResult.Value);
        Assert.Equal(countryId, returnValue.Id);
    }

    //[Fact]
    //public void CreateCountry_ReturnsCreatedAtActionResult()
    //{
    //    // Arrange
    //    var country = new Country { Id = 1, Name = "Country1" };
    //    _mockService.Setup(service => service.CreateCountry(country)).Returns(country);

    //    // Act
    //    var result = _controller.CreateCountry(country);

    //    // Assert
    //    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    //    var returnValue = Assert.IsType<Country>(createdAtActionResult.Value);
    //    Assert.Equal(country.Id, returnValue.Id);
    //}

    //[Fact]
    //public void UpdateCountry_ReturnsNoContentResult()
    //{
    //    // Arrange
    //    int countryId = 1;
    //    var country = new Country { Id = countryId, Name = "UpdatedCountry" };
    //    _mockService.Setup(service => service.UpdateCountry(countryId, country)).Returns(true);

    //    // Act
    //    var result = _controller.UpdateCountry(countryId, country);

    //    // Assert
    //    Assert.IsType<NoContentResult>(result);
    //}

    //[Fact]
    //public void DeleteCountry_ReturnsNoContentResult()
    //{
    //    // Arrange
    //    int countryId = 1;
    //    _mockService.Setup(service => service.DeleteCountry(countryId)).Returns(true);

    //    // Act
    //    var result = _controller.DeleteCountry(countryId);

    //    // Assert
    //    Assert.IsType<NoContentResult>(result);
    //}
}