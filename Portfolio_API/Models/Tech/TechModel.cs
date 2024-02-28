using System.Text.Json.Serialization;

namespace Portfolio_API;

public class TechModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? TopicId { get; set; }
    [JsonIgnore]
    public virtual TopicModel? Topic { get; set; }
}
