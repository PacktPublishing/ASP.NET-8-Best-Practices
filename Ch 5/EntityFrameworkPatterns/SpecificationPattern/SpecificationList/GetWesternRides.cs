using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.SpecificationPattern.SpecificationList;

public class GetWesternRides : BaseSpecificationService<Attraction>
{
    public GetWesternRides(IThemeParkDbContext context) : base(context)
    {
        Specification = new Specification<Attraction>(
            e => e.Location.Name == "Western");
    }
}