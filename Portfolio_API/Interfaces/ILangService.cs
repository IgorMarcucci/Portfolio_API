using FluentResults;

namespace Portfolio_API;

public interface ILangService
{
    public Task<List<ReadLangDto>>? GetLangs();
    public Task<ReadLangDto?> GetLangByIdAsync(int id);
    public Task<Result> CreateLangAsync(CreateLangDto createLangDto);
    public Task<Result> UpdateLangAsync(int id, UpdateLangDto updateLangDto);
    public Task<Result> DeleteLangAsync(int id);
}
