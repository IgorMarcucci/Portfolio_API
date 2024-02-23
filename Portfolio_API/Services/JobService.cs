using System.Runtime.InteropServices;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class JobService : IJobService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public JobService(ApplicationDatabaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<ReadJobDto>>? GetJobs()
    {
        List<JobModel> jobs = await _db.Jobs.ToListAsync();

        List<ReadJobDto> listJobs = _mapper.Map<List<ReadJobDto>>(jobs);

        return listJobs;
    }

    public async Task<Result> CreateJobAsync(CreateJobDto createJobDto)
    {
        var job = _mapper.Map<JobModel>(createJobDto);
        _db.Jobs.Add(job);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateJobAsync(int id, UpdateJobDto updateJobDto)
    {
        JobModel? job = await _db.Jobs.FindAsync(id);
        if (job == null)
        {
            return Result.Fail("Job not found!");
        }

        _mapper.Map(updateJobDto, job);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteJobAsync(int id)
    {
        JobModel? job = await _db.Jobs.FindAsync(id);
        if (job == null)
        {
            return Result.Fail("Job not found!");
        }

        _db.Jobs.Remove(job);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<ReadJobDto?> GetJobByIdAsync(int id)
    {
        JobModel? job = await _db.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        ReadJobDto? jobObject = _mapper.Map<ReadJobDto>(job);

        return jobObject;
    }
}
