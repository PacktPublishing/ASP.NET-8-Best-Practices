using System.ComponentModel.DataAnnotations.Schema;

namespace EFApplication.DataContext.Models;

public partial class Location
{
    [NotMapped]
    public int AttractionCount => Attractions.Count;
}
