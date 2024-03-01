namespace Portfolio_API;

public interface ITopicService
{
    Task<List<ReadTopicDto>> GetAllTopics();
    Task<ReadTopicDto> GetTopicById(int id);
    Task<List<ReadTopicDto>> GetTopicsByLanguageId(int languageId);
    Task<ReadTopicDto> CreateTopic(CreateTopicDto createTopicDto);
    Task<ReadTopicDto?> UpdateTopic(int id, UpdateTopicDto updateTopicDto);
    Task<bool> DeleteTopic(int id);
}
