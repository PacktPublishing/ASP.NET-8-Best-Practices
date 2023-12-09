using System.ComponentModel.DataAnnotations.Schema;

namespace ThemePark.Data.DataContext.Models;

public partial class Location
{
    [NotMapped]
    public int AttractionCount => Attractions.Count;
}
