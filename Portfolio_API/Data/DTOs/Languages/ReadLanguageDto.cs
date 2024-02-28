namespace Portfolio_API;

public class ReadLanguageDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<JobModel>? Jobs { get; set; }
    public virtual List<ProjectModel>? Projects { get; set; }
    public virtual List<TopicModel>? Topics { get; set; }
}
