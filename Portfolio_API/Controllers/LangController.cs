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
        List<ReadLangDTO>? langsDTO = await _langService.GetLangs();
        if (langsDTO == null)
            return NotFound();
        return Ok(langsDTO);
    }

    // [Authorize]
    [HttpPost("/createlang")]
    public async Task<IActionResult> CreateLangAsync([FromBody] CreateLangDTO createLangDTO)
    {
        Result result = await _langService.CreateLangAsync(createLangDTO);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updatelang/{id}")]
    public async Task<IActionResult> UpdateLangAsync(int id, [FromBody] UpdateLangDTO updateLangDTO)
    {
        Result result = await _langService.UpdateLangAsync(id, updateLangDTO);
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
        ReadLangDTO? langDTO = await _langService.GetLangByIdAsync(id);
        if (langDTO == null)
            return NotFound();
        return Ok(langDTO);
    }
}
