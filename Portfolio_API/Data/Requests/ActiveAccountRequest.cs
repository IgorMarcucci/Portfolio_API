using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class ActiveAccountRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string? ActivationCode{ get; set; }
}
