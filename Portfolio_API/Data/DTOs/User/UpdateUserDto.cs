namespace Portfolio_API;

public class UpdateUserDto
{
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
}
