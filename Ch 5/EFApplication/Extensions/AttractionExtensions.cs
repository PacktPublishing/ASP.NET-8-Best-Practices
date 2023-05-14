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
}