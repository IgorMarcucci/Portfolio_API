namespace Portfolio_API;

public class ReadJobDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Description { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public virtual LangModel[]? Langs { get; set; }
}
