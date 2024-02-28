using System.Text.Json.Serialization;

namespace Portfolio_API;

public class ProjectModel
{
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public int? JobId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    [JsonIgnore]
    public virtual List<LangModel>? Langs { get; set; }   
    [JsonIgnore]
    public virtual JobModel? Job { get; set; }
    [JsonIgnore]
    public virtual LanguageModel? Language { get; set; }
}
