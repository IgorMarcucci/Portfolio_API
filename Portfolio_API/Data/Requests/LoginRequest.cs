﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio_API;

public class LoginRequest
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
