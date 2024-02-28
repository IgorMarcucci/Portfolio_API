namespace Portfolio_API;

public interface ILanguageService
{
    public Task<List<ReadLanguageDto>> GetAllLanguages();
    public Task<ReadLanguageDto> GetLanguageById(int id);
    public Task<ReadLanguageDto> CreateLanguage(CreateLanguageDto createLanguageDto);
    public Task<ReadLanguageDto?> UpdateLanguage(int id, UpdateLanguageDto updateLanguageDto);
    public Task<bool> DeleteLanguage(int id);
}
