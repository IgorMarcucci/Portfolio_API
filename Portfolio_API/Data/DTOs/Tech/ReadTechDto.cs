namespace Portfolio_API;

public class ReadTechDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? TopicId { get; set; }
    public virtual TopicModel? Topic { get; set; }
}
