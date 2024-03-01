namespace Portfolio_API;

public class ReadLangDto
{
    public int Id { get; set; }
    public string? Name { get; set; }  
    public virtual List<ReadTopicDto>? Topics { get; set; }

}
