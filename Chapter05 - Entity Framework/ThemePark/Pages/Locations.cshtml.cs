using EntityFrameworkThemePark.DataContext.Models;
using EntityFrameworkThemePark.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntityFrameworkThemePark.Pages
{
    public class LocationsModel : PageModel
    {
        private readonly ILogger<LocationsModel> _logger;
        private readonly ILocationService _locationService;

        public List<Location> Locations { get; set; } = null!;

        public LocationsModel(
            ILogger<LocationsModel> logger, 
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        public async Task OnGetAsync(int id)
        {
            Locations = await _locationService.GetLocationsAsync();
        }
    }
}