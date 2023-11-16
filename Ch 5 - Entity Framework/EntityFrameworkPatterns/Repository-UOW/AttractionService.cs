using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.Repository_UOW;

public class AttractionService : IAttractionService
{
    private readonly ThemeParkDbContext _context;

    public AttractionService(ThemeParkDbContext context)
    {
        _context = context;
    }

    public List<Attraction> GetAttractions()
    {
        return _context.Attractions.ToList();
    }
        
    public Attraction GetAttraction(int id)
    {
        return _context.Attractions
            .FirstOrDefault(e => e!.Id == id, null)!;
    }
}