using Microsoft.EntityFrameworkCore;
using ThemePark.DataContext;
using ThemePark.DataContext.Models;

namespace ThemePark.Services;

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
            .Include<Attraction, Location>(r=> r.Location)
            .ToListAsync();
    }
}