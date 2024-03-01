using AutoMapper;

namespace Portfolio_API;

public class TechProfile : Profile
{
    public TechProfile()
    {
        CreateMap<TechModel, ReadTechDto>();
        CreateMap<CreateTechDto, TechModel>();
        CreateMap<UpdateTechDto, TechModel>();
    }
}
