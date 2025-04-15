using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using vigilant_umbrella.Controllers.V1;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;
using vigilant_umbrella_infrastructure.UnitOfWork;

namespace vigilant_umbrella_test.Api;

public class CountriesTest
{
    private readonly Mock<ICountriesAppServices> _mockService;
    private readonly CountriesController _controller;

    public CountriesTest()
    {
        _mockService = new Mock<ICountriesAppServices>();
        _controller = new CountriesController(_mockService.Object);
    }

    [Fact]
    public async Task GetAllCountries_ReturnsOkResult()
    {
        // Arrange
        var countries = new List<vigilant_umbrella_application.Dtos.V1.Countries.Country>
        {
            new() { Id = Guid.NewGuid(), Code = "CD" }
        };
        var request = new GetCountriesRequest(); // Create a GetRequest object
        _mockService.Setup(service => service.Get(request)).ReturnsAsync(countries);

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
        vigilant_umbrella_application.Dtos.V1.Countries.Country? country = null;
        _mockService.Setup(service => service.GetSingle(It.IsAny<Guid>())).ReturnsAsync(country);

        // Act
        var result = await _controller.GetSingle(Guid.NewGuid());

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
        _mockService.Setup(service => service.GetSingle(countryId)).ReturnsAsync(country);

        // Act
        var result = await _controller.GetSingle(countryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<vigilant_umbrella_application.Dtos.V1.Countries.Country>(okResult.Value);
        Assert.Equal(countryId, returnValue.Id);
    }

    [Fact]
    public async Task CreateCountry_ReturnsOkResult()
    {
        // Arrange
        var request = new PostCountryRequest { Code = "CD" };
        var result = new vigilant_umbrella_application.Dtos.Result { Success = true };
        _mockService.Setup(service => service.Post(request)).ReturnsAsync(result);

        // Act
        var response = await _controller.Post(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        var returnValue = Assert.IsType<vigilant_umbrella_application.Dtos.Result>(okResult.Value);
        Assert.True(returnValue.Success);
    }

    [Fact]
    public async Task UpdateCountry_ReturnsOkResult()
    {
        // Arrange
        Guid countryId = Guid.NewGuid();
        var request = new PutCountryRequest { Code = "CD" };
        var result = new vigilant_umbrella_application.Dtos.Result { Success = true };
        _mockService.Setup(service => service.Put(countryId, request)).ReturnsAsync(result);

        // Act
        var response = await _controller.Put(countryId, request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        var returnValue = Assert.IsType<vigilant_umbrella_application.Dtos.Result>(okResult.Value);
        Assert.True(returnValue.Success);
    }

    [Fact]
    public async Task DeleteCountry_ReturnsOkResult()
    {
        // Arrange
        Guid countryId = Guid.NewGuid();
        var result = new vigilant_umbrella_application.Dtos.Result { Success = true };
        _mockService.Setup(service => service.Delete(countryId)).ReturnsAsync(result);

        // Act
        var response = await _controller.Delete(countryId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(response);
        var returnValue = Assert.IsType<vigilant_umbrella_application.Dtos.Result>(okResult.Value);
        Assert.True(returnValue.Success);
    }
}
