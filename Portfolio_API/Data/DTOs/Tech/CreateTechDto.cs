using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateTechDto
{
    [Required]
    public required string Name { get; set; }
    public int? TopicId { get; set; }
}
