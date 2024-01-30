using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class AskPassResetRequest
{
    [Required]
    public string? Email { get; set; }
}
