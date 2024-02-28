﻿namespace Portfolio_API;

public class UpdateJobDto
{
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
