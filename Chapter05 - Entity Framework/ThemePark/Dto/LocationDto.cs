namespace EntityFrameworkThemePark.Dto;

public class LocationDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<AttractionDto> Attractions { get; set; } = new List<AttractionDto>();
}