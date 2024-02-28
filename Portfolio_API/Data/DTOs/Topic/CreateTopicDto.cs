using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateTopicDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required int LanguageId { get; set; }
}
