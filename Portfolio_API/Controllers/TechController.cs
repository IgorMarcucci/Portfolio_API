using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class TechController : ControllerBase
{
    private readonly ITechService _techService;

    public TechController(ITechService techService)
    {
        _techService = techService;
    }

    [HttpGet("/techs")]
    public async Task<IActionResult> GetTechs()
    {
        List<ReadTechDto> techsDto = await _techService.GetAllTechs();
        if (techsDto == null)
            return NotFound();
        return Ok(techsDto);
    }

    [HttpGet("/tech/{id}")]
    public async Task<IActionResult> GetTechById(int id)
    {
        ReadTechDto? techDto = await _techService.GetTechById(id);
        if (techDto == null)
            return NotFound();
        return Ok(techDto);
    }

    // [Authorize]
    [HttpPost("/createTech")]
    public async Task<IActionResult> CreateTech([FromBody] CreateTechDto createTechDto)
    {
        ReadTechDto result = await _techService.CreateTech(createTechDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpPut("/updateTech/{id}")]
    public async Task<IActionResult> UpdateTech(int id, [FromBody] UpdateTechDto updateTechDto)
    {
        ReadTechDto? result = await _techService.UpdateTech(id, updateTechDto);
        if (result != null)
            return Ok(result);
        return BadRequest(result);
    }

    // [Authorize]
    [HttpDelete("/deleteTech/{id}")]
    public async Task<IActionResult> DeleteTech(int id)
    {
        bool result = await _techService.DeleteTech(id);
        if (result)
            return Ok(result);
        return BadRequest(result);
    }
}
