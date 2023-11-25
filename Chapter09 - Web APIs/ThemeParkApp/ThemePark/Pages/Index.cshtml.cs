using Microsoft.AspNetCore.Mvc.RazorPages;
using ThemePark.Data.Dto;
using ThemePark.Data.Extensions;
using ThemePark.Services.Services;

namespace ThemePark.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IAttractionService _attractionService;

    public IEnumerable<AttractionDto> Attractions { get; set; } = null!;

    public IndexModel(
        ILogger<IndexModel> logger, 
        IAttractionService attractionService)
    {
        _logger = logger;
        _attractionService = attractionService;
    }

    public async Task OnGetAsync()
    {
        var attractions = await _attractionService.GetAttractionsAsync();
        Attractions = attractions.Select(t => t.ToDto());
    }
}
