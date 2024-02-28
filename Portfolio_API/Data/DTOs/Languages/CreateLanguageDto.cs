using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateLanguageDto
{
    [Required]
    public required string Name { get; set; }
}
