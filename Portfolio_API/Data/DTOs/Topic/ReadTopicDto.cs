namespace Portfolio_API;

public class ReadTopicDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? LanguageId { get; set; }
    public int? LangId { get; set; }
    public List<TechModel>? Techs { get; set; }
    public virtual LanguageModel? Language { get; set; }
    public virtual LangModel? Lang { get; set; }
}
