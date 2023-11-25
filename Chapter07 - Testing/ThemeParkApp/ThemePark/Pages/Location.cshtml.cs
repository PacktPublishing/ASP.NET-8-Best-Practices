using Microsoft.AspNetCore.Mvc.RazorPages;
using ThemePark.DataContext.Models;
using ThemePark.Services;

namespace ThemePark.Pages
{
    public class LocationModel : PageModel
    {
        private readonly ILogger<LocationModel> _logger;
        private readonly ILocationService _locationService;

        public Location Location { get; set; } = null!;

        public LocationModel(
            ILogger<LocationModel> logger, 
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        public async Task OnGetAsync(int id)
        {
            Location = await _locationService.GetLocationAsync(id);
        }
    }
}