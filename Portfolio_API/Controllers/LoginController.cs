using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet("/getuserbyid/{id}")]
    [Authorize()]
    public IActionResult GetUserByIdAsync(int id)
    {
        ReadUserDto? readDto = _loginService.GetUserById(id);
        if (readDto != null)
        {
            return Ok(readDto);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult LoginUser(LoginRequest request)
    {
        Result result = _loginService.LoginUser(request);
        if (result.IsFailed) return Unauthorized(result);
        return Ok(result);
    }

    [HttpPost("/ask-passreset")]
    public IActionResult AskPasswordReset(AskPassResetRequest request)
    {
        Result result = _loginService.AskPasswordReset(request);
        if (result.IsFailed) return Unauthorized(result);

        return Ok(result);
    }

    [HttpPost("/do-passreset")]
    public IActionResult ResetPassword(DoPassResetRequest request)
    {
        Result result = _loginService.ResetPassword(request);
        if (result.IsFailed) return Unauthorized(result);
        return Ok(result);
    }
}
