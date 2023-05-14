using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThemePark.DataContext.Models;

public partial class Attraction
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column("LocationID")]
    public int LocationId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Attractions")]
    public virtual Location Location { get; set; } = null!;
}