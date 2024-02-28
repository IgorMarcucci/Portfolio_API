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
        List<ReadJobDto> jobsDto = await _jobService.GetAllJobs();
        if (jobsDto == null)
            return NotFound();
        return Ok(jobsDto);
    }

    // [Authorize]
    [HttpGet("/job/{id}")]
    public async Task<IActionResult> GetJobById(int id)
    {
        ReadJobDto jobDto = await _jobService.GetJobById(id);
        if (jobDto == null)
            return NotFound();
        return Ok(jobDto);
    }

    // [Authorize]
    [HttpPost("/createjob")]
    public async Task<IActionResult> CreateJob(CreateJobDto createJobDto)
    {
        Console.WriteLine(createJobDto);
        ReadJobDto result = await _jobService.CreateJob(createJobDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updatejob/{id}")]
    public async Task<IActionResult> UpdateJob(int id, [FromBody] UpdateJobDto updateJobDto)
    {
        ReadJobDto? result = await _jobService.UpdateJob(id, updateJobDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deletejob/{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        bool? result = await _jobService.DeleteJob(id);
        if (result == true)
            return Ok(result);
        return BadRequest(result);
    }
}
