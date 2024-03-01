using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class LoginRequest
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}
