using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;

namespace EntityFrameworkPatterns.SpecificationPattern.SpecificationList;

public class GetAllAttractions : BaseSpecificationService<Attraction>
{
    public GetAllAttractions(IThemeParkDbContext context) : base(context)
    {
    }
}