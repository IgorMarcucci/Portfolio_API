using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

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
        List<ReadJobDTO>? jobsDTO = await _jobService.GetJobs();
        if (jobsDTO == null)
            return NotFound();
        return Ok(jobsDTO);
    }

    [Authorize]
    [HttpGet("/job/{id}")]
    public async Task<IActionResult> GetJobByIdAsync(int id)
    {
        ReadJobDTO? jobDTO = await _jobService.GetJobByIdAsync(id);
        if (jobDTO == null)
            return NotFound();
        return Ok(jobDTO);
    }

    [Authorize]
    [HttpPost("/createjob")]
    public IActionResult CreateJobAsync([FromBody] CreateJobDTO createJobDTO)
    {
        Result result = _jobService.CreateJobAsync(createJobDTO);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [Authorize]
    [HttpPut("/updatejob/{id}")]
    public IActionResult UpdateJobAsync(int id, [FromBody] UpdateJobDTO updateJobDTO)
    {
        Result result = _jobService.UpdateJobAsync(id, updateJobDTO).Result;
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [Authorize]
    [HttpDelete("/deletejob/{id}")]
    public IActionResult DeleteJobAsync(int id)
    {
        Result result = _jobService.DeleteJobAsync(id).Result;
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}
