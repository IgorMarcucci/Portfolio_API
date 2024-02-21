using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateLangDto
{   
    [Required]
    public string? Name { get; set; }
}
