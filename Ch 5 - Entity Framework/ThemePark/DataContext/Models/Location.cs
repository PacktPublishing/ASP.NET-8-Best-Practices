using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkThemePark.DataContext.Models;

public partial class Location
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Location")]
    public virtual ICollection<Attraction> Attractions { get; } = new List<Attraction>();
}