using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateLangDTO
{   
    [Required]
    public string? Name { get; set; }
}
