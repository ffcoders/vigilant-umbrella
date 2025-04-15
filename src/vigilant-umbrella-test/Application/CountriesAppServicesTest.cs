namespace vigilant_umbrella_test.Application;

using AutoMapper;
using Moq;
using System.Linq.Expressions;
using vigilant_umbrella_application.Services.V1.Countries;
using vigilant_umbrella_application.Services.V1.Countries.Requests;
using vigilant_umbrella_domain.Entities;
using vigilant_umbrella_domain.Entities.Countries;
using vigilant_umbrella_infrastructure.UnitOfWork;
using Xunit;

public class CountriesAppServicesTest
{
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CountriesAppServices _service;

    public CountriesAppServicesTest()
    {
        _mockUow = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _service = new CountriesAppServices(_mockUow.Object, _mockMapper.Object);
    }

    [Fact(Skip = "Still need to adjust repositories to support mock")]
    public async Task Get_ShouldReturnCountries()
    {
        // Arrange
        var countries = new List<Country>
        {
            new Country { Id = Guid.NewGuid(), Code = "US" }
        };
        var request = new GetCountriesRequest();
        _mockUow.Setup(uow => uow.Countries.Get(It.IsAny<Expression<Func<Country, bool>>>(), It.IsAny<Func<IQueryable<Country>, IOrderedQueryable<Country>>>(), It.IsAny<string>()))
                .ReturnsAsync(countries);
        _mockMapper.Setup(mapper => mapper.Map<List<vigilant_umbrella_application.Dtos.V1.Countries.Country>>(countries))
                   .Returns(new List<vigilant_umbrella_application.Dtos.V1.Countries.Country>
                   {
                       new vigilant_umbrella_application.Dtos.V1.Countries.Country { Id = countries.First().Id, Code = "US" }
                   });

        // Act
        var result = await _service.Get(request);

        // Assert
        Assert.Single(result);
        Assert.Equal("US", result.First().Code);
    }

    [Fact(Skip = "Still need to adjust repositories to support mock")]
    public async Task GetSingle_ShouldReturnCountry()
    {
        // Arrange
        var countryId = Guid.NewGuid();
        var country = new Country { Id = countryId, Code = "US" };
        _mockUow.Setup(uow => uow.Countries.GetById(countryId)).ReturnsAsync(country);
        _mockMapper.Setup(mapper => mapper.Map<vigilant_umbrella_application.Dtos.V1.Countries.Country>(country))
                   .Returns(new vigilant_umbrella_application.Dtos.V1.Countries.Country { Id = countryId, Code = "US" });

        // Act
        var result = await _service.GetSingle(countryId);

        // Assert
        Assert.Equal("US", result.Code);
    }

    [Fact(Skip = "Still need to adjust repositories to support mock")]
    public async Task Post_ShouldCreateCountry()
    {
        // Arrange
        var request = new PostCountryRequest { Code = "US" };
        var country = new Country { Id = Guid.NewGuid(), Code = "US" };
        _mockMapper.Setup(mapper => mapper.Map<vigilant_umbrella_domain.Entities.Countries.Country>(It.IsAny<vigilant_umbrella_application.Dtos.V1.Countries.Country>()))
                   .Returns(country);
        _mockUow.Setup(uow => uow.Countries.Add(country)).ReturnsAsync(country);
        _mockUow.Setup(uow => uow.CompleteAsync()).ReturnsAsync(1);

        // Act
        var result = await _service.Post(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact(Skip = "Still need to adjust repositories to support mock")]
    public async Task Put_ShouldUpdateCountry()
    {
        // Arrange
        var countryId = Guid.NewGuid();
        var request = new PutCountryRequest { Code = "US" };
        var country = new Country { Id = countryId, Code = "US" };
        _mockUow.Setup(uow => uow.Countries.GetById(countryId)).ReturnsAsync(country);
        _mockUow.Setup(uow => uow.Countries.Update(country)).Returns(country);
        _mockUow.Setup(uow => uow.CompleteAsync()).ReturnsAsync(1);

        // Act
        var result = await _service.Put(countryId, request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact(Skip = "Still need to adjust repositories to support mock")]
    public async Task Delete_ShouldRemoveCountry()
    {
        // Arrange
        var countryId = Guid.NewGuid();
        var country = new Country { Id = countryId, Code = "US" };
        _mockUow.Setup(uow => uow.Countries.GetById(countryId)).ReturnsAsync(country);
        _mockUow.Setup(uow => uow.Countries.Delete(countryId)).ReturnsAsync(true);
        _mockUow.Setup(uow => uow.CompleteAsync()).ReturnsAsync(1);

        // Act
        var result = await _service.Delete(countryId);

        // Assert
        Assert.True(result.Success);
    }
}
