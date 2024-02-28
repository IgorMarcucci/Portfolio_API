namespace Portfolio_API;

public class ReadProjectDto
{
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public virtual List<LangModel>? Langs { get; set; }
    public virtual JobModel? Job { get; set; }
    public virtual LanguageModel? Language { get; set; }
}
