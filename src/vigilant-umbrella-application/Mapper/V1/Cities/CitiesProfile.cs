namespace vigilant_umbrella_application.Mapper.V1.Cities;

using AutoMapper;

/// <summary>
/// Defines the <see cref="CitiesProfile"/>.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class CitiesProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CitiesProfile"/> class.
    /// </summary>
    public CitiesProfile()
    {
        this.CreateMap<Dtos.V1.Cities.City, vigilant_umbrella_domain.Entities.Cities.City>()
            .ReverseMap();
    }
}
