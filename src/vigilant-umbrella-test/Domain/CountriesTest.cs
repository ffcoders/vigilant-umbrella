using vigilant_umbrella_domain.Entities.Countries;

namespace vigilant_umbrella_test.Domain;

public class CountryTest
{
    [Fact]
    public void Country_ShouldHaveValidProperties()
    {
        // Arrange
        var country = new Country
        {
            Id = Guid.NewGuid(),
            Code = "US"
        };

        // Act & Assert
        Assert.True(country.Id != Guid.Empty);
        Assert.Equal("US", country.Code);
    }
}
