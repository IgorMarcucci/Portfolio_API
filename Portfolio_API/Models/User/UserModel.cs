using System.Text.Json.Serialization;

namespace Portfolio_API;

public class UserModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public JobModel[]? Jobs { get; set; }
}
