namespace Portfolio_API;

public class ReadJobDto
{
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual List<ProjectModel>? Projects { get; set; }
    public virtual LanguageModel? Language { get; set; }
}
