using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public LanguageService(ApplicationDatabaseContext context, IMapper mapper)
    {
        _db = context;
        _mapper = mapper;
    }

    public async Task<List<ReadLanguageDto>> GetAllLanguages()
    {
        List<LanguageModel>? languages = await _db.Languages.Include(x => x.Jobs).Include(x => x.Projects).Include(x => x.Topics).ToListAsync();
        List<ReadLanguageDto> listLanguages = _mapper.Map<List<ReadLanguageDto>>(languages);

        return listLanguages ?? new List<ReadLanguageDto>();
    }

    public async Task<ReadLanguageDto> GetLanguageById(int id)
    {
        LanguageModel? language = await _db.Languages.Include(x => x.Jobs).Include(x => x.Projects).Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ReadLanguageDto>(language) ?? new ReadLanguageDto();
    }

    public async Task<ReadLanguageDto> CreateLanguage(CreateLanguageDto createLanguageDto)
    {
        var language = _mapper.Map<LanguageModel>(createLanguageDto);
        _db.Languages.Add(language);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadLanguageDto>(language);
    }

    public async Task<ReadLanguageDto?> UpdateLanguage(int id, UpdateLanguageDto updateLanguageDto)
    {
        var language = await _db.Languages.FirstOrDefaultAsync(x => x.Id == id);
        if (language == null) return null;
        _mapper.Map(updateLanguageDto, language);
        await _db.SaveChangesAsync();
        return _mapper.Map<ReadLanguageDto>(language);
    }

    public async Task<bool> DeleteLanguage(int id)
    {
        var language = await _db.Languages.FirstOrDefaultAsync(x => x.Id == id);
        if (language == null) return false;
        _db.Languages.Remove(language);
        await _db.SaveChangesAsync();
        return true;
    }
}