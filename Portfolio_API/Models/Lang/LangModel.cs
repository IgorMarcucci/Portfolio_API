﻿namespace Portfolio_API;

public class LangModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual List<TopicModel>? Topics { get; set; }
}
