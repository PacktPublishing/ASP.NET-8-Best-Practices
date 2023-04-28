namespace EFApplication.Dto;

public class AttractionDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
}
