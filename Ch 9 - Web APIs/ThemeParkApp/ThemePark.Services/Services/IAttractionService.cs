using ThemePark.Data.DataContext.Models;

namespace ThemePark.Services.Services;

public interface IAttractionService
{
    Task<List<Attraction>> GetAttractionsAsync();
}