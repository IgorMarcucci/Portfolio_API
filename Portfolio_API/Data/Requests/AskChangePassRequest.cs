using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class AskChangePassRequest
{
    [Required]
    public string? Email { get; set; }
}
