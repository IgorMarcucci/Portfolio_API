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

    public async Task<List<ReadJobDto>> GetAllJobs()
    {
        List<JobModel>? jobs = await _db.Jobs.Include(x => x.Projects).Include(x => x.Language).ToListAsync();
        List<ReadJobDto> listJobs = _mapper.Map<List<ReadJobDto>>(jobs);

        return listJobs ?? new List<ReadJobDto>();
    }

    public async Task<ReadJobDto> GetJobById(int id)
    {
        JobModel? job = await _db.Jobs.Include(x => x.Projects).Include(x => x.Language).FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadJobDto>(job) ?? new ReadJobDto();
    }

    public async Task<List<ReadJobDto>> GetJobsByLanguageId(int languageId)
    {
        List<JobModel>? jobs = await _db.Jobs.Where(x => x.LanguageId == languageId).Include(x => x.Projects).ToListAsync();
        List<ReadJobDto> listJobs = _mapper.Map<List<ReadJobDto>>(jobs);

        return listJobs ?? new List<ReadJobDto>();
    }

    public async Task<ReadJobDto> CreateJob(CreateJobDto createJobDto)
    {
        var job = _mapper.Map<JobModel>(createJobDto);
        _db.Jobs.Add(job);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadJobDto>(job);
    }

    public async Task<ReadJobDto?> UpdateJob(int id, UpdateJobDto updateJobDto)
    {
        var job = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
        if (job == null) return null;
        _mapper.Map(updateJobDto, job);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadJobDto>(job);
    }

    public async Task<bool> DeleteJob(int id)
    {
        var job = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
        if (job == null) return false;
        _db.Jobs.Remove(job);
        await _db.SaveChangesAsync();
        return true;
    }
}

