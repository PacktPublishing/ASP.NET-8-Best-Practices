using EFApplication.DataContext;
using EFApplication.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EFApplication.Services;

public class LocationService : ILocationService
{
    private readonly IThemeParkDbContext _context;

    public LocationService(IThemeParkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _context.Locations
            .Include(t=> t.Attractions)
            .ToListAsync();
    }
    
    public async Task<Location> GetLocationAsync(int id)
    {
        return (await _context.Locations
            .Include(t => t.Attractions)
            .FirstOrDefaultAsync(e => e.Id.Equals(id), CancellationToken.None))!;
    }
}