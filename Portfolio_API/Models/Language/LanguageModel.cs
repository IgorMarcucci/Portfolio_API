using System.Text.Json.Serialization;

namespace Portfolio_API;

public class LanguageModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public virtual List<JobModel>? Jobs { get; set; }
    [JsonIgnore]
    public virtual List<ProjectModel>? Projects { get; set; }
    [JsonIgnore]
    public virtual List<TopicModel>? Topics { get; set; }
}
