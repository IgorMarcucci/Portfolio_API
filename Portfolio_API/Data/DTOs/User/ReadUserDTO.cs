namespace Portfolio_API;

public class ReadUserDto
{
    public int Id {get; set;}
    public string? UserName { get; set; }
    public string? NormalizedUserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public virtual List<JobModel>? Jobs { get; set; }
}