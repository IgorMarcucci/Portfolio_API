using AutoMapper;

namespace Portfolio_API;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectModel, ReadProjectDto>();
        CreateMap<CreateProjectDto, ProjectModel>();
        CreateMap<UpdateProjectDto, ProjectModel>();
    }
}
