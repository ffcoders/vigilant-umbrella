namespace vigilant_umbrella_application.Mapper.V1.Countries;

using AutoMapper;

/// <summary>
/// Defines the <see cref="CountriesProfile"/>.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class CountriesProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CountriesProfile"/> class.
    /// </summary>
    public CountriesProfile()
    {
        this.CreateMap<Dtos.V1.Countries.Country, vigilant_umbrella_domain.Entities.Countries.Country>()
            .ReverseMap();
    }
}
