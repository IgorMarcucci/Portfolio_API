using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateJobDTO
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Company { get; set; }
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    [Required]
    public string? Description { get; set; }
}
