using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class LangService : ILangService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public LangService(ApplicationDatabaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<ReadLangDto>> GetAllLangs()
    {
        List<LangModel>? langs = await _db.Langs.ToListAsync();
        List<ReadLangDto> listLangs = _mapper.Map<List<ReadLangDto>>(langs);

        return listLangs ?? new List<ReadLangDto>();
    }

    public async Task<ReadLangDto> GetLangById(int id)
    {
        LangModel? lang = await _db.Langs.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadLangDto>(lang) ?? new ReadLangDto();
    }

    public async Task<ReadLangDto> CreateLang(CreateLangDto createLangDto)
    {
        var lang = _mapper.Map<LangModel>(createLangDto);
        _db.Langs.Add(lang);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadLangDto>(lang);
    }

    public async Task<ReadLangDto?> UpdateLang(int id, UpdateLangDto updateLangDto)
    {
        var lang = await _db.Langs.FirstOrDefaultAsync(x => x.Id == id);
        if (lang == null) return null;
        _mapper.Map(updateLangDto, lang);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadLangDto>(lang);
    }

    public async Task<bool> DeleteLang(int id)
    {
        var lang = await _db.Langs.FirstOrDefaultAsync(x => x.Id == id);
        if (lang == null) return false;
        _db.Langs.Remove(lang);
        await _db.SaveChangesAsync();
        return true;
    }
}

