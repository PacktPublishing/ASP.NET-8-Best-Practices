using ThemePark.DataContext.Models;

namespace ThemePark.Services;

public interface ILocationService
{
    Task<List<Location>> GetLocationsAsync();
    Task<Location> GetLocationAsync(int id);
}