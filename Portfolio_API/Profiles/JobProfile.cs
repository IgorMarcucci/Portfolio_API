using AutoMapper;

namespace Portfolio_API;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<JobModel, ReadJobDto>();
        CreateMap<CreateJobDto, JobModel>();
        CreateMap<UpdateJobDto, JobModel>();
    }
}
