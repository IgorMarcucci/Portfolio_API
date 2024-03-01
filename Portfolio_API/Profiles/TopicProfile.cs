using AutoMapper;

namespace Portfolio_API;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<TopicModel, ReadTopicDto>();
        CreateMap<CreateTopicDto, TopicModel>();
        CreateMap<UpdateTopicDto, TopicModel>();
    }
}
