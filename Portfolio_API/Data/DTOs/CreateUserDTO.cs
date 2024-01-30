using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateUserDto
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    [Compare("Password")]
    public string? PasswordConfirm { get; set; }
}
