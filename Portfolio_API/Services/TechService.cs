using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class TechService : ITechService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public TechService(ApplicationDatabaseContext context, IMapper mapper)
    {
        _db = context;
        _mapper = mapper;
    }

    public async Task<List<ReadTechDto>> GetAllTechs()
    {
        List<TechModel>? techs = await _db.Techs.ToListAsync();
        List<ReadTechDto> listTechs = _mapper.Map<List<ReadTechDto>>(techs);

        return listTechs ?? new List<ReadTechDto>();
    }

    public async Task<ReadTechDto> GetTechById(int id)
    {
        TechModel? tech = await _db.Techs.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadTechDto>(tech) ?? new ReadTechDto();
    }

    public async Task<ReadTechDto> CreateTech(CreateTechDto createTechDto)
    {
        var tech = _mapper.Map<TechModel>(createTechDto);
        _db.Techs.Add(tech);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadTechDto>(tech);
    }

    public async Task<ReadTechDto?> UpdateTech(int id, UpdateTechDto updateTechDto)
    {
        var tech = await _db.Techs.FirstOrDefaultAsync(x => x.Id == id);
        if (tech == null) return null;
        _mapper.Map(updateTechDto, tech);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadTechDto>(tech);
    }

    public async Task<bool> DeleteTech(int id)
    {
        var tech = await _db.Techs.FirstOrDefaultAsync(x => x.Id == id);
        if (tech == null) return false;
        _db.Techs.Remove(tech);
        await _db.SaveChangesAsync();
        return true;
    }
}