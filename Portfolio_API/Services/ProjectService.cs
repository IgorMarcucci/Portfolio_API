using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class ProjectService : IProjectService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public ProjectService(ApplicationDatabaseContext context, IMapper mapper)
    {
        _db = context;
        _mapper = mapper;
    }

    public async Task<List<ReadProjectDto>> GetAllProjects()
    {
        List<ProjectModel>? projects = await _db.Projects.Include(x => x.Job).Include(x => x.Language).ToListAsync();
        List<ReadProjectDto> listProjects = _mapper.Map<List<ReadProjectDto>>(projects);

        return listProjects ?? new List<ReadProjectDto>();
    }

    public async Task<ReadProjectDto> GetProjectById(int id)
    {
        ProjectModel? project = await _db.Projects.Include(x => x.Job).Include(x => x.Language).FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadProjectDto>(project) ?? new ReadProjectDto();
    }

    public async Task<List<ReadProjectDto>> GetProjectsByLanguageId(int languageId)
    {
        List<ProjectModel>? projects = await _db.Projects.Include(x => x.Job).Where(x => x.LanguageId == languageId).ToListAsync();
        List<ReadProjectDto> listProjects = _mapper.Map<List<ReadProjectDto>>(projects);

        return listProjects ?? new List<ReadProjectDto>();
    }

    public async Task<List<ReadProjectDto>> GetProjectsByJobId(int jobId)
    {
        List<ProjectModel>? projects = await _db.Projects.Include(x => x.Language).Where(x => x.JobId == jobId).ToListAsync();
        List<ReadProjectDto> listProjects = _mapper.Map<List<ReadProjectDto>>(projects);
        return listProjects ?? new List<ReadProjectDto>();
    }

    public async Task<ReadProjectDto> CreateProject(CreateProjectDto createProjectDto)
    {
        var project = _mapper.Map<ProjectModel>(createProjectDto);
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadProjectDto>(project);
    }

    public async Task<ReadProjectDto> AddLangToProject(int projectId, int langId)
    {
        var project = await _db.Projects.Include(x => x.Langs).FirstOrDefaultAsync(x => x.Id == projectId);
        var lang = await _db.Langs.FirstOrDefaultAsync(x => x.Id == langId);
        if (project == null || lang == null) return new ReadProjectDto();
        project. = lang;
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadProjectDto>(project);
    }

    public async Task<ReadProjectDto?> UpdateProject(int id, UpdateProjectDto updateProjectDto)
    {
        var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        if (project == null) return null;
        _mapper.Map(updateProjectDto, project);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadProjectDto>(project);
    }

    public async Task<bool> DeleteProject(int id)
    {
        var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        if (project == null) return false;
        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();
        return true;
    }
}