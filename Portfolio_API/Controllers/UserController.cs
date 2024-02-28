using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

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

    [HttpPut("/updateUser/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        Result result = await _userService.UpdateUserAsync(id, updateUserDto);
        return HandleResult(result);
    }

    [HttpGet("/getuserbyid/{id}")]
    // [Authorize()]
    public IActionResult GetUserByIdAsync(int id)
    {
        ReadUserDto? readDto = _userService.GetUserById(id);
        return readDto != null ? Ok(readDto) : NotFound();
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginRequest request)
    {
        return HandleResult(_userService.Login(request));
    }
}
