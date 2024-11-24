using vigilant_umbrella_domain.Entities.Cities;

namespace vigilant_umbrella_test.Domain;

public class CitiesTest
{
    [Fact]
    public void Country_ShouldHaveValidProperties()
    {
        // Arrange
        var city = new City
        {
            Id = Guid.NewGuid(),
            Code = "NY",
            Name = "New York"
        };

        // Act & Assert
        Assert.True(city.Id != Guid.Empty);
        Assert.Equal("NY", city.Code);
    }
}
