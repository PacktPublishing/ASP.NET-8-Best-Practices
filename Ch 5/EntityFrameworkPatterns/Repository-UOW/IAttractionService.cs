using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.Repository_UOW;

public interface IAttractionService
{
    List<Attraction> GetAttractions();
    Attraction GetAttraction(int id);
}