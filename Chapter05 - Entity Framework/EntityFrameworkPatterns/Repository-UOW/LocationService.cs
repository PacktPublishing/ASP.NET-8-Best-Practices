using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.Repository_UOW;

public class LocationService : ILocationService
{
    private readonly IThemeParkDbContext _context;

    public LocationService(IThemeParkDbContext context)
    {
        _context = context;
    }

    public List<Location> GetLocations()
    {
        return _context.Locations.ToList();
    }
        
    public Location GetLocation(int id)
    {
        return _context.Locations.FirstOrDefault(e => e!.Id == id, null)!;
    }
}