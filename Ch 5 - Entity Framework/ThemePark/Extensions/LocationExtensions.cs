using EntityFrameworkThemePark.DataContext.Models;
using EntityFrameworkThemePark.Dto;

namespace EntityFrameworkThemePark.Extensions;

public static class LocationExtensions
{
    public static LocationDto ToDto(this Location location)
    {
        return new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Attractions = location.Attractions.Select(r=> r.ToDto())
        };
    }
}