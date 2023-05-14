using ThemePark.DataContext.Models;
using ThemePark.Dto;

namespace ThemePark.Extensions;

public static class AttractionExtensions
{
    public static AttractionDto ToDto(this Attraction attraction)
    {
        return new AttractionDto
        {
            Id = attraction.Id,
            Name = attraction.Name,
            LocationId = attraction.LocationId,
            LocationName = attraction.Location == null 
                ? string.Empty 
                : attraction.Location.Name
        };
    }
}