namespace Portfolio_API;

public interface ITechService
{
    Task<List<ReadTechDto>> GetAllTechs();
    Task<ReadTechDto> GetTechById(int id);
    Task<ReadTechDto> CreateTech(CreateTechDto createTechDto);
    Task<ReadTechDto?> UpdateTech(int id, UpdateTechDto updateTechDto);
    Task<bool> DeleteTech(int id);
}
