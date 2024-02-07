using FluentResults;

namespace Portfolio_API;

public interface IJobService
{
    public Task<List<ReadJobDTO>>? GetJobs();
    public Result CreateJobAsync(CreateJobDTO createJobDTO);
    public Task<Result> UpdateJobAsync(int id, UpdateJobDTO updateJobDTO);
    public Task<Result> DeleteJobAsync(int id);
    public Task<ReadJobDTO?> GetJobByIdAsync(int id);
}
