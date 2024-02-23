using FluentResults;

namespace Portfolio_API;

public interface IJobService
{
    public Task<List<ReadJobDto>>? GetJobs();
    public Task<Result> CreateJobAsync(CreateJobDto createJobDto);
    public Task<Result> UpdateJobAsync(int id, UpdateJobDto updateJobDto);
    public Task<Result> DeleteJobAsync(int id);
    public Task<ReadJobDto?> GetJobByIdAsync(int id);
}
