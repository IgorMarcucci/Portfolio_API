using FluentResults;

namespace Portfolio_API;

public interface IJobService
{
    Task<List<ReadJobDto>> GetAllJobs();
    Task<ReadJobDto> GetJobById(int id);
    Task<ReadJobDto> CreateJob(CreateJobDto createJobDto);
    Task<ReadJobDto?> UpdateJob(int id, UpdateJobDto updateJobDto);
    Task<bool> DeleteJob(int id);
}
