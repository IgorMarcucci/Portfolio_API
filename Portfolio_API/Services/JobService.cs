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
        List<JobModel> jobs = await _db.Jobs.Include(j => j.Langs).Include(j => j.User).ToListAsync();

        List<ReadJobDto> listJobs = _mapper.Map<List<ReadJobDto>>(jobs);

        return listJobs;
    }

    public async Task<Result> CreateJobAsync(CreateJobDto createJobDto)
    {
        var user = _db.Users.Include(u => u.Jobs).FirstOrDefault(t => t.Id == createJobDto.UserId);
        if (user == null)
        {
            return Result.Fail("User not found!");
        }

        var job = new JobModel
        {
            Title = createJobDto.Title,
            Description = createJobDto.Description,
            StartDate = createJobDto.StartDate,
            Location = createJobDto.Location,
            Company = createJobDto.Company,
            UserId = createJobDto.UserId,
            User = user
        };
        user.Jobs.Add(job);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateJobAsync(int id, UpdateJobDto updateJobDto)
    {
        JobModel job = await _db.Jobs.FindAsync(id);
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
        JobModel job = await _db.Jobs.FindAsync(id);
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
        JobModel job = await _db.Jobs.Include(j => j.Langs).FirstOrDefaultAsync(j => j.Id == id);
        ReadJobDto jobObject = _mapper.Map<ReadJobDto>(job);

        return jobObject;
    }

    public async Task<Result> AddLangToJobAsync(int jobId, int langId)
    {
        JobModel job = await _db.Jobs.Include(j => j.Langs).FirstOrDefaultAsync(j => j.Id == jobId);
        LangModel lang = await _db.Langs.FindAsync(langId);
        if (job == null || lang == null)
        {
            return Result.Fail("Job or Lang not found!");
        }

        job.Langs.Add(lang);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }
}
