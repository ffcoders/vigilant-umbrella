//using Moq;
//using vigilant_umbrella_application.Services.V1.Countries;
//using vigilant_umbrella_application.Services.V1.Countries.Requests;
//using vigilant_umbrella_domain.Entities;
//using Xunit;

//namespace vigilant_umbrella_test.Application
//{
//    public class CountriesAppServicesTest
//    {
//        private readonly Mock<ICountriesRepository> _mockRepository;
//        private readonly CountriesAppServices _service;

//        public CountriesAppServicesTest()
//        {
//            _mockRepository = new Mock<ICountriesRepository>();
//            _service = new CountriesAppServices(_mockRepository.Object);
//        }

//        [Fact]
//        public async Task Get_ShouldReturnCountries()
//        {
//            // Arrange
//            var countries = new List<Country>
//            {
//                new Country { Id = Guid.NewGuid(), Code = "US" }
//            };
//            var request = new GetRequest();
//            _mockRepository.Setup(repo => repo.Get(request)).ReturnsAsync(countries);

//            // Act
//            var result = await _service.Get(request);

//            // Assert
//            Assert.Single(result);
//            Assert.Equal("US", result.First().Code);
//        }
//    }
//}
