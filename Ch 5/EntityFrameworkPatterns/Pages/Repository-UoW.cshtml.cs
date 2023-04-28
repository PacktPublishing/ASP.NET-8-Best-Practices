using EntityFrameworkPatterns.DataContext.Models;
using EntityFrameworkPatterns.Repository_UOW;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntityFrameworkPatterns.Pages
{
    public class RepositoryModel : PageModel
    {
        private readonly ILogger<RepositoryModel> _logger;
        private readonly IAttractionService _service;

        public List<Attraction> Attractions { get; set; } = null!;

        public RepositoryModel(ILogger<RepositoryModel> logger, 
            IAttractionService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
            Attractions = _service.GetAttractions().ToList();
        }
    }
}