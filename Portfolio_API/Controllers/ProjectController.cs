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

    // [Authorize]
    [HttpGet("/projects/language/{id}")]
    public async Task<IActionResult> GetProjectsByLanguageId(int id)
    {
        List<ReadProjectDto> projectsDto = await _projectService.GetProjectsByLanguageId(id);
        if (projectsDto == null)
            return NotFound();
        return Ok(projectsDto);
    }

    // [Authorize]
    [HttpGet("/projects/job/{id}")]
    public async Task<IActionResult> GetProjectsByJobId(int id)
    {
        List<ReadProjectDto> projectsDto = await _projectService.GetProjectsByJobId(id);
        if (projectsDto == null)
            return NotFound();
        return Ok(projectsDto);
    }

    [HttpPost("/createProject")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
    {
        ReadProjectDto result = await _projectService.CreateProject(createProjectDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/addLangToProject/{projectId}/{langId}")]
    public async Task<IActionResult> AddLangToProject(int projectId, int langId)
    {
        ReadProjectDto result = await _projectService.AddLangToProject(projectId, langId);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut("/updateProject/{id}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
    {
        ReadProjectDto? result = await _projectService.UpdateProject(id, updateProjectDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("/deleteProject/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        bool result = await _projectService.DeleteProject(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
}
