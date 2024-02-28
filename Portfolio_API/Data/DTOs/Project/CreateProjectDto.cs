using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateProjectDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required int LanguageId { get; set; }
    [Required]
    public required string Description { get; set; }
    public string? Link { get; set; }
    public int? JobId { get; set; }

}
