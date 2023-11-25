using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.Repository_UOW;

[Obsolete("This is a repository on top of a repository; Not necessary")]
public class AttractionRepository
{
    private readonly ThemeParkDbContext _context;

    public AttractionRepository(ThemeParkDbContext context)
    {
        _context = context;
    }

    public List<Attraction> GetAttractions()
    {
        return _context.Attractions.ToList();
    }
        
    public Attraction GetAttraction(int id)
    {
        return _context.Attractions.FirstOrDefault(e => e.Id == id)!;
    }
}