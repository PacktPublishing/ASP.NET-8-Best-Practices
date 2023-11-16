using EntityFrameworkThemePark.DataContext.Models;

namespace EntityFrameworkThemePark.Services;

public interface IAttractionService
{
    Task<List<Attraction>> GetAttractionsAsync();
}