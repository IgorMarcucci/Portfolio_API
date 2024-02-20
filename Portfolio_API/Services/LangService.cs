using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class LangService : ILangService
{
    private readonly ApplicationDatabaseContext _db;
    private IMapper _mapper;

    public LangService(ApplicationDatabaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<ReadLangDTO>>? GetLangs()
    {
        List<LangModel> langs = await _db.Langs.ToListAsync();

        List<ReadLangDTO> listLangs = _mapper.Map<List<ReadLangDTO>>(langs);

        return listLangs;
    }

    public async Task<Result> CreateLangAsync(CreateLangDTO createLangDTO)
    {
        LangModel lang = _mapper.Map<LangModel>(createLangDTO);
        _db.Langs.Add(lang);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateLangAsync(int id, UpdateLangDTO updateLangDTO)
    {
        LangModel lang = await _db.Langs.FindAsync(id);
        if (lang == null)
        {
            return Result.Fail("Lang not found!");
        }

        _mapper.Map(updateLangDTO, lang);
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

    public async Task<ReadLangDTO?> GetLangByIdAsync(int id)
    {
        LangModel? lang = await _db.Langs.FindAsync(id);
        if (lang == null)
        {
            return null;
        }

        ReadLangDTO readLangDTO = _mapper.Map<ReadLangDTO>(lang);
        return readLangDTO;
    }
}
