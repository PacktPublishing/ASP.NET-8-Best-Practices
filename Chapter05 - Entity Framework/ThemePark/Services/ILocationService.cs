using EntityFrameworkThemePark.DataContext.Models;

namespace EntityFrameworkThemePark.Services;

public interface ILocationService
{
    Task<List<Location>> GetLocationsAsync();
    Task<Location> GetLocationAsync(int id);
}