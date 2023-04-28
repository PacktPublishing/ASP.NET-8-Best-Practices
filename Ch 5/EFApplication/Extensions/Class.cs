using EFApplication.DataContext.Models;
using EFApplication.Dto;

namespace EFApplication.Extensions;

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
}public static class LocationExtensions
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