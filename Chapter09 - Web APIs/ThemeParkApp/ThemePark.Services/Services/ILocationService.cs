using ThemePark.Data.DataContext.Models;

namespace ThemePark.Services.Services;

public interface ILocationService
{
    Task<List<Location>> GetLocationsAsync();
    Task<Location> GetLocationAsync(int id);
}