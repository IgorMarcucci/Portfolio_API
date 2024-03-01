namespace Portfolio_API;

public interface IProjectService
{
    Task<List<ReadProjectDto>> GetAllProjects();
    Task<ReadProjectDto> GetProjectById(int id);
    Task<List<ReadProjectDto>> GetProjectsByLanguageId(int languageId);
    Task<List<ReadProjectDto>> GetProjectsByJobId(int jobId);
    Task<ReadProjectDto> CreateProject(CreateProjectDto createProjectDto);
    Task<ReadProjectDto> AddLangToProject(int projectId, int langId);
    Task<ReadProjectDto?> UpdateProject(int id, UpdateProjectDto updateProjectDto);
    Task<bool> DeleteProject(int id);
}
