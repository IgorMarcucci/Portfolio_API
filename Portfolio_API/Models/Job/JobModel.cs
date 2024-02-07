using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace Portfolio_API;

public class JobModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Location { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public LangModel[]? Langs { get; set; }
}
