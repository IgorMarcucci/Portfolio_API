using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class DoPassResetRequest
{
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string? PasswordConfirm { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Token { get; set; }
}
