using AutoMapper;

namespace Portfolio_API;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobModel, ReadJobDTO>();
        CreateMap<CreateJobDTO, JobModel>();
        CreateMap<UpdateJobDTO, JobModel>();
    }
}
