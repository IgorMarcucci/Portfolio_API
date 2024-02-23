using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateJobDto
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Company { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public string? Description { get; set; }
}
