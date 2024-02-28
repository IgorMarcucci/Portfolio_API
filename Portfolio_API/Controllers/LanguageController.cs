using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class LanguageController : ControllerBase
{
    private readonly ILanguageService _languageService;

    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet("/languages")]
    public async Task<IActionResult> GetLanguages()
    {
        List<ReadLanguageDto> languagesDto = await _languageService.GetAllLanguages();
        if (languagesDto == null)
            return NotFound();
        return Ok(languagesDto);
    }

    [HttpGet("/language/{id}")]
    public async Task<IActionResult> GetLanguageById(int id)
    {
        ReadLanguageDto? languageDto = await _languageService.GetLanguageById(id);
        if (languageDto == null)
            return NotFound();
        return Ok(languageDto);
    }

    // [Authorize]
    [HttpPost("/createlanguage")]
    public async Task<IActionResult> CreateLanguage([FromBody] CreateLanguageDto createLanguageDto)
    {
        ReadLanguageDto result = await _languageService.CreateLanguage(createLanguageDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updatelanguage/{id}")]
    public async Task<IActionResult> UpdateLanguage(int id, [FromBody] UpdateLanguageDto updateLanguageDto)
    {
        ReadLanguageDto? result = await _languageService.UpdateLanguage(id, updateLanguageDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deletelanguage/{id}")]
    public async Task<IActionResult> DeleteLanguage(int id)
    {
        bool result = await _languageService.DeleteLanguage(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
}
