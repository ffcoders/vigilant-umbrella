using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using vigilant_umbrella.Controllers.V1;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

namespace vigilant_umbrella_test;

public class UnitTest1
{
    private readonly Mock<ICountriesAppServices> _mockService;
    private readonly Mock<ILogger<CountriesController>> _mockLogger;
    private readonly CountriesController _controller;

    public UnitTest1()
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
        var result = _controller.Get(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<vigilant_umbrella_application.Dtos.V1.Countries.Country>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public void GetCountryById_ReturnsNotFoundResult()
    {
        // Arrange
        Guid countryId = Guid.NewGuid();
        _mockService.Setup(service => service.GetSingle(countryId)).Returns(Task.FromResult<vigilant_umbrella_application.Dtos.V1.Countries.Country>(null));

        // Act
        var result = _controller.GetSingle(countryId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetCountryById_ReturnsOkResult()
    {
        // Arrange
        Guid countryId = Guid.NewGuid();
        var country = new vigilant_umbrella_application.Dtos.V1.Countries.Country { Id = countryId, Code = "CD" };
        _mockService.Setup(service => service.GetSingle(countryId)).Returns(Task.FromResult(country));

        // Act
        var result = _controller.GetSingle(countryId);

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