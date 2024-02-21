using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace Portfolio_API;

public class JobModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Location { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public virtual List<LangModel>? Langs { get; set; }
    [JsonIgnore]
    public virtual UserModel? User { get; set; }
}
