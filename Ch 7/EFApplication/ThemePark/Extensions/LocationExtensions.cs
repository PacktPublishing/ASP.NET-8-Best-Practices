using ThemePark.DataContext.Models;
using ThemePark.Dto;

namespace ThemePark.Extensions;

public static class LocationExtensions
{
    public static LocationDto ToDto(this Location location)
    {
        return new LocationDto
        {
            Id = location.Id,
            Name = location.Name,
            Attractions = Enumerable.Select<Attraction, AttractionDto>(location.Attractions, r=> AttractionExtensions.ToDto(r))
        };
    }
}