using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class TopicController : ControllerBase
{
    private readonly ITopicService _topicService;

    public TopicController(ITopicService topicService)
    {
        _topicService = topicService;
    }

    [HttpGet("/topics")]
    public async Task<IActionResult> GetTopics()
    {
        List<ReadTopicDto> topicsDto = await _topicService.GetAllTopics();
        if (topicsDto == null)
            return NotFound();
        return Ok(topicsDto);
    }

    [HttpGet("/topic/{id}")]
    public async Task<IActionResult> GetTopicById(int id)
    {
        ReadTopicDto? topicDto = await _topicService.GetTopicById(id);
        if (topicDto == null)
            return NotFound();
        return Ok(topicDto);
    }

    [HttpGet("/topics/language/{id}")]
    public async Task<IActionResult> GetTopicsByLanguageId(int id)
    {
        List<ReadTopicDto> topicsDto = await _topicService.GetTopicsByLanguageId(id);
        if (topicsDto == null)
            return NotFound();
        return Ok(topicsDto);
    }

    // [Authorize]
    [HttpPost("/createTopic")]
    public async Task<IActionResult> CreateTopic([FromBody] CreateTopicDto createTopicDto)
    {
        ReadTopicDto result = await _topicService.CreateTopic(createTopicDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updateTopic/{id}")]
    public async Task<IActionResult> UpdateTopic(int id, [FromBody] UpdateTopicDto updateTopicDto)
    {
        ReadTopicDto? result = await _topicService.UpdateTopic(id, updateTopicDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deleteTopic/{id}")]
    public async Task<IActionResult> DeleteTopic(int id)
    {
        bool result = await _topicService.DeleteTopic(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
    
}
