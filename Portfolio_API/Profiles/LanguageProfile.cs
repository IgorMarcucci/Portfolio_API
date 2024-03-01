using AutoMapper;

namespace Portfolio_API;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageModel, ReadLanguageDto>();
        CreateMap<CreateLanguageDto, LanguageModel>();
        CreateMap<UpdateLanguageDto, LanguageModel>();
    }
}
