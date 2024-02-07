using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class JobService : IJobService
{
    private readonly ApplicationDatabaseContext _db;
    private IMapper _mapper;

    public JobService(ApplicationDatabaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<ReadJobDTO>>? GetJobs()
    {
        List<JobModel> jobs = await _db.Jobs.Include(j => j.Langs).ToListAsync();

        List<ReadJobDTO> listJobs = _mapper.Map<List<ReadJobDTO>>(jobs);

        return listJobs;
    }

    public Result CreateJobAsync(CreateJobDTO createJobDTO)
    {
        JobModel job = _mapper.Map<JobModel>(createJobDTO);
        _db.Jobs.Add(job);
        _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateJobAsync(int id, UpdateJobDTO updateJobDTO)
    {
        JobModel job = await _db.Jobs.FindAsync(id);
        if (job == null)
        {
            return Result.Fail("Job not found!");
        }

        _mapper.Map(updateJobDTO, job);
        _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteJobAsync(int id)
    {
        JobModel job = await _db.Jobs.FindAsync(id);
        if (job == null)
        {
            return Result.Fail("Job not found!");
        }

        _db.Jobs.Remove(job);
        _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<ReadJobDTO?> GetJobByIdAsync(int id)
    {
        JobModel job = await _db.Jobs.Include(j => j.Langs).FirstOrDefaultAsync(j => j.Id == id);
        ReadJobDTO jobObject = _mapper.Map<ReadJobDTO>(job);

        return jobObject;
    }
}
