using AutoMapper;

namespace Portfolio_API;

public class LangProfile : Profile
{
    public LangProfile()
    {
        CreateMap<LangModel, ReadLangDTO>();
        CreateMap<CreateLangDTO, LangModel>();
        CreateMap<UpdateLangDTO, LangModel>();
    }
}
