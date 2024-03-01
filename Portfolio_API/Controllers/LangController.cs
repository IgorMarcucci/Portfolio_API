using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class LangController : ControllerBase
{
    private readonly ILangService _langService;

    public LangController(ILangService authService)
    {
        _langService = authService;
    }

    [HttpGet("/langs")]
    public async Task<IActionResult> GetLangs()
    {
        List<ReadLangDto> langsDto = await _langService.GetAllLangs();
        if (langsDto == null)
            return NotFound();
        return Ok(langsDto);
    }

    [HttpGet("/lang/{id}")]
    public async Task<IActionResult> GetLangById(int id)
    {
        ReadLangDto? langDto = await _langService.GetLangById(id);
        if (langDto == null)
            return NotFound();
        return Ok(langDto);
    }

    // [Authorize]
    [HttpPost("/createLang")]
    public async Task<IActionResult> CreateLang([FromBody] CreateLangDto createLangDto)
    {
        ReadLangDto result = await _langService.CreateLang(createLangDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updateLang/{id}")]
    public async Task<IActionResult> UpdateLang(int id, [FromBody] UpdateLangDto updateLangDto)
    {
        ReadLangDto? result = await _langService.UpdateLang(id, updateLangDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deleteLang/{id}")]
    public async Task<IActionResult> DeleteLang(int id)
    {
        bool result = await _langService.DeleteLang(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
}
