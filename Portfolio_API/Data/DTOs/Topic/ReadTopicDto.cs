namespace Portfolio_API;

public class ReadTopicDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<TechModel>? Techs { get; set; }
    public virtual LanguageModel? Language { get; set; }
}
