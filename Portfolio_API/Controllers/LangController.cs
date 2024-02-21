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
        List<ReadLangDto>? langsDto = await _langService.GetLangs();
        if (langsDto == null)
            return NotFound();
        return Ok(langsDto);
    }

    // [Authorize]
    [HttpPost("/createlang")]
    public async Task<IActionResult> CreateLangAsync([FromBody] CreateLangDto createLangDto)
    {
        Result result = await _langService.CreateLangAsync(createLangDto);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updatelang/{id}")]
    public async Task<IActionResult> UpdateLangAsync(int id, [FromBody] UpdateLangDto updateLangDto)
    {
        Result result = await _langService.UpdateLangAsync(id, updateLangDto);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deletelang/{id}")]
    public async Task<IActionResult> DeleteLangAsync(int id)
    {
        Result result = await _langService.DeleteLangAsync(id);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("/lang/{id}")]
    public async Task<IActionResult> GetLangByIdAsync(int id)
    {
        ReadLangDto? langDto = await _langService.GetLangByIdAsync(id);
        if (langDto == null)
            return NotFound();
        return Ok(langDto);
    }
}
