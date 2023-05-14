using EFApplication.DataContext.Models;

namespace EFApplication.Services;

public interface ILocationService
{
    Task<List<Location>> GetLocationsAsync();
    Task<Location> GetLocationAsync(int id);
}