using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

[Route("[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("/jobs")]
    public async Task<IActionResult> GetJobs()
    {
        List<ReadJobDto>? jobsDto = await _jobService.GetJobs();
        if (jobsDto == null)
            return NotFound();
        return Ok(jobsDto);
    }

    // [Authorize]
    [HttpGet("/job/{id}")]
    public async Task<IActionResult> GetJobByIdAsync(int id)
    {
        ReadJobDto? jobDto = await _jobService.GetJobByIdAsync(id);
        if (jobDto == null)
            return NotFound();
        return Ok(jobDto);
    }

    // [Authorize]
    [HttpPost("/createjob")]
    public async Task<IActionResult> CreateJobAsync(CreateJobDto createJobDto)
    {
        Console.WriteLine(createJobDto);
        Result result = await _jobService.CreateJobAsync(createJobDto);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updatejob/{id}")]
    public IActionResult UpdateJobAsync(int id, [FromBody] UpdateJobDto updateJobDto)
    {
        Result result = _jobService.UpdateJobAsync(id, updateJobDto).Result;
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deletejob/{id}")]
    public IActionResult DeleteJobAsync(int id)
    {
        Result result = _jobService.DeleteJobAsync(id).Result;
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/applylang/{jobId}/{langId}")]
    public async Task<IActionResult> AddLangToJobAsync(int jobId, int langId)
    {
        Result result = await _jobService.AddLangToJobAsync(jobId, langId);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
