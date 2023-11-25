using EntityFrameworkThemePark.DataContext;
using EntityFrameworkThemePark.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkThemePark.Services;

public class AttractionService : IAttractionService
{
    private readonly IThemeParkDbContext _context;

    public AttractionService(IThemeParkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Attraction>> GetAttractionsAsync()
    {
        return await _context.Attractions
            .AsNoTracking()
            .Include(r=> r.Location)
            .ToListAsync();
    }
}