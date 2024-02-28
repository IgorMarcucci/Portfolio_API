using System.Text.Json.Serialization;

namespace Portfolio_API;

public class LangModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public virtual List<TopicModel>? Topics { get; set; }
}
