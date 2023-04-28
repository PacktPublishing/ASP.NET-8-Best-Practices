using EntityFrameworkPatterns.DataContext;
using EntityFrameworkPatterns.DataContext.Models;
using EntityFrameworkPatterns.ExtensionMethods;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntityFrameworkPatterns.Pages;

public class ExtensionMethodModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IThemeParkDbContext _context;

    public List<Location> Locations { get; set; } = null!;

    public ExtensionMethodModel(ILogger<IndexModel> logger, 
        IThemeParkDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        Locations = _context.GetLocations().ToList();
    }
}