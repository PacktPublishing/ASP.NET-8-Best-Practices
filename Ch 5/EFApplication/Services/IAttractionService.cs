using EFApplication.DataContext.Models;

namespace EFApplication.Services;

public interface IAttractionService
{
    Task<List<Attraction>> GetAttractionsAsync();
}