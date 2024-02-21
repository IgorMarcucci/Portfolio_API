using AutoMapper;

namespace Portfolio_API;

public class LangProfile : Profile
{
    public LangProfile()
    {
        CreateMap<LangModel, ReadLangDto>();
        CreateMap<CreateLangDto, LangModel>();
        CreateMap<UpdateLangDto, LangModel>();
    }
}
