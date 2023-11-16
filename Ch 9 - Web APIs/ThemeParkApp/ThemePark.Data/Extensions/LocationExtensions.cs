using ThemePark.Data.DataContext.Models;
using ThemePark.Data.Dto;

namespace ThemePark.Data.Extensions;

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