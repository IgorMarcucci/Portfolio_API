﻿using System.Text.Json.Serialization;

namespace Portfolio_API;

public class TopicModel
{
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public int? LangId { get; set; }
    public string? Name { get; set; }
    [JsonIgnore]
    public virtual List<TechModel>? Techs { get; set; }
    [JsonIgnore]
    public virtual LanguageModel? Language { get; set; }
    [JsonIgnore]
    public virtual LangModel? Lang { get; set; }
}
