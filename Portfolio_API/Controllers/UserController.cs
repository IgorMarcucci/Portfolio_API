using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    private IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
            return NoContent();
        return BadRequest(result);
    }

    [HttpGet("/users")]
    public async Task<IActionResult> GetUsers()
    {
        List<ReadUserDto>? usersDto = await _userService.GetUsers();

        if (usersDto == null)
            return NotFound();
        return Ok(usersDto);
    }

    [HttpPut("/updateuser/{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        Result result = _userService.UpdateUserAsync(id, updateUserDto).Result;
        return HandleResult(result);
    }
}
