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

    public async Task<List<ReadLangDto>>? GetLangs()
    {
        List<LangModel> langs = await _db.Langs.ToListAsync();

        List<ReadLangDto> listLangs = _mapper.Map<List<ReadLangDto>>(langs);

        return listLangs;
    }

    public async Task<Result> CreateLangAsync(CreateLangDto createLangDto)
    {
        LangModel lang = _mapper.Map<LangModel>(createLangDto);
        _db.Langs.Add(lang);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateLangAsync(int id, UpdateLangDto updateLangDto)
    {
        LangModel lang = await _db.Langs.FindAsync(id);
        if (lang == null)
        {
            return Result.Fail("Lang not found!");
        }

        _mapper.Map(updateLangDto, lang);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteLangAsync(int id)
    {
        LangModel lang = await _db.Langs.FindAsync(id);
        if (lang == null)
        {
            return Result.Fail("Lang not found!");
        }

        _db.Langs.Remove(lang);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<ReadLangDto?> GetLangByIdAsync(int id)
    {
        LangModel? lang = await _db.Langs.FindAsync(id);
        if (lang == null)
        {
            return null;
        }

        ReadLangDto ReadLangDto = _mapper.Map<ReadLangDto>(lang);
        return ReadLangDto;
    }
}
