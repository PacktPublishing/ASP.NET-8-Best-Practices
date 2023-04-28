using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.ExtensionMethods;

public static class LocationExtensions
{
    public static List<Location> GetLocations(this IThemeParkDbContext context)
    {
        return context.Locations.ToList();
    }
        
    public static Location GetLocation(this IThemeParkDbContext context, int id)
    {
        return context.Locations.FirstOrDefault(e => e!.Id == id, null)!;
    }
}
