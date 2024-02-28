namespace Portfolio_API;

public interface IProjectService
{
    Task<List<ReadProjectDto>> GetAllProjects();
    Task<ReadProjectDto> GetProjectById(int id);
    Task<List<ReadProjectDto>> GetProjectsByLanguageId(int languageId);
    Task<ReadProjectDto> CreateProject(CreateProjectDto createProjectDto);
    Task<ReadProjectDto?> UpdateProject(int id, UpdateProjectDto updateProjectDto);
    Task<bool> DeleteProject(int id);
}
