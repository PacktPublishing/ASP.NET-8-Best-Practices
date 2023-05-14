using ThemePark.DataContext.Models;

namespace ThemePark.Services;

public interface IAttractionService
{
    Task<List<Attraction>> GetAttractionsAsync();
}