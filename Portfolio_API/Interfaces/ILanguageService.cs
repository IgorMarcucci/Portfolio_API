namespace Portfolio_API;

public interface ILanguageService
{
    public Task<List<ReadLanguageDto>> GetAllLanguages();
    public Task<ReadLanguageDto> GetLanguageById(int id);
    public Task<ReadLanguageDto> CreateLanguage(CreateLangDto createLangDto);
    public Task<ReadLanguageDto?> UpdateLanguage(int id, UpdateLangDto updateLangDto);
    public Task<bool> DeleteLanguage(int id);
}
