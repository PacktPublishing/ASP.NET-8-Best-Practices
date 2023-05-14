using EFApplication.DataContext.Models;
using EFApplication.Dto;

namespace EFApplication.Extensions;

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