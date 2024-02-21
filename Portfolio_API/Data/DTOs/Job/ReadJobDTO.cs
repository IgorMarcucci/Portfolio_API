namespace Portfolio_API;

public class ReadJobDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual LangModel[]? Langs { get; set; }
    public virtual UserModel? User { get; set; }
}
