using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPatterns.ExtensionMethods;

public static class AttractionExtensions
{
    public static IQueryable<Attraction> GetAttractions(this IThemeParkDbContext context)
    {
        return context.Attractions;
    }
        
    public static Attraction GetAttraction(this IThemeParkDbContext context, int id)
    {
        return context.Attractions
            .Include(t => t.Location)
            .FirstOrDefault(e => e!.Id == id, null)!;
    }

    public static IQueryable<Attraction> GetWesternRides(this IThemeParkDbContext context)
    {
        return context.Attractions
            .Include(t => t.Location)
            .Where(e => e.Location.Name.Equals("Western"));
    }
}
