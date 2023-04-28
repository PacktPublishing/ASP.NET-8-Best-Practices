using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;
using EntityFrameworkPatterns.SpecificationPattern.SpecificationList;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntityFrameworkPatterns.Pages
{
    public class SpecificationModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IThemeParkDbContext _context;

        public List<Attraction> Attractions { get; set; } = null!;

        public SpecificationModel(ILogger<IndexModel> logger, 
            IThemeParkDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            var westernAttractions = new GetWesternRides(_context);
            Attractions = westernAttractions.GetQuery().ToList();
        }
    }
}