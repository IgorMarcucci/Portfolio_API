﻿namespace Portfolio_API;

public class UpdateProjectDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public int? JobId { get; set; }
    public int? LanguageId { get; set; }
}
