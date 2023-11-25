using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkThemePark.DataContext.Models;

public partial class Location
{
    [NotMapped]
    public int AttractionCount => Attractions.Count;
}
