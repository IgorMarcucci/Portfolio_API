using FluentResults;

namespace Portfolio_API;

public interface ILangService
{
    Task<List<ReadLangDto>> GetAllLangs();
    Task<ReadLangDto> GetLangById(int id);
    Task<ReadLangDto> CreateLang(CreateLangDto createLangDto);
    Task<ReadLangDto?> UpdateLang(int id, UpdateLangDto updateLangDto);
    Task<bool> DeleteLang(int id);
}