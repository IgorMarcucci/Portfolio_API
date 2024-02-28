using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class ProjectService
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
        List<ProjectModel>? projects = await _db.Projects.ToListAsync();
        List<ReadProjectDto> listProjects = _mapper.Map<List<ReadProjectDto>>(projects);

        return listProjects ?? new List<ReadProjectDto>();
    }

    public async Task<ReadProjectDto> GetProjectById(int id)
    {
        ProjectModel? project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadProjectDto>(project) ?? new ReadProjectDto();
    }

    public async Task<ReadProjectDto> CreateProject(CreateLangDto createLangDto)
    {
        var project = _mapper.Map<ProjectModel>(createLangDto);
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadProjectDto>(project);
    }

    public async Task<ReadProjectDto?> UpdateProject(int id, UpdateLangDto updateLangDto)
    {
        var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        if (project == null) return null;
        _mapper.Map(updateLangDto, project);
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
