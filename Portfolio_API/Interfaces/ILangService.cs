using FluentResults;

namespace Portfolio_API;

public interface ILangService
{
    public Task<List<ReadLangDTO>>? GetLangs();
    public Task<ReadLangDTO?> GetLangByIdAsync(int id);
    public Task<Result> CreateLangAsync(CreateLangDTO createLangDTO);
    public Task<Result> UpdateLangAsync(int id, UpdateLangDTO updateLangDTO);
    public Task<Result> DeleteLangAsync(int id);
}
