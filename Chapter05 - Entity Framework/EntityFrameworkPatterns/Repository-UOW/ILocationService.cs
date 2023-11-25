using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.Repository_UOW;

public interface ILocationService
{
    List<Location> GetLocations();
    Location GetLocation(int id);
}