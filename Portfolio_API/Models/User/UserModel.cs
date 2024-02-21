using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Portfolio_API;

public class UserModel : IdentityUser<int>
{
    [JsonIgnore]
    public List<JobModel>? Jobs { get; set; }
}
