using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
    }

    [HttpGet("/projects")]
    public async Task<IActionResult> GetProjects()
    {
        List<ReadProjectDto> projectsDto = await _projectService.GetAllProjects();
        if (projectsDto == null)
            return NotFound();
        return Ok(projectsDto);
    }

    [HttpGet("/project/{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        ReadProjectDto projectDto = await _projectService.GetProjectById(id);
        if (projectDto == null)
            return NotFound();
        return Ok(projectDto);
    }

    [HttpPost("/createproject")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
    {
        ReadProjectDto result = await _projectService.CreateProject(createProjectDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut("/updateproject/{id}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
    {
        ReadProjectDto? result = await _projectService.UpdateProject(id, updateProjectDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("/deleteproject/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        bool result = await _projectService.DeleteProject(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
}
