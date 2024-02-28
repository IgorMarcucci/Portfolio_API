using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class CreateUserDto
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    [Compare("Password")]
    public required string PasswordConfirm { get; set; }
}
