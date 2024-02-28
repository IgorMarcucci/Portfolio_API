using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateLangDto
{   
    [Required]
    public required string Name { get; set; }
}
