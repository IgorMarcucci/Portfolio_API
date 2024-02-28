using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateJobDto
{
    [Required]
    public required string Title { get; set; }
    [Required]
    public required int LanguageId { get; set; }
    [Required]
    public required string Company { get; set; }
    [Required]
    public required string Location { get; set; }
    [Required]
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public required string Description { get; set; }
}
