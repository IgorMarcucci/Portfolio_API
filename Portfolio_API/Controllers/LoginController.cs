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
        return readDto != null ? Ok(readDto) : NotFound();
    }

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        return HandleResult(_loginService.Login(request));
    }

    [HttpPost("/ask-change-pass")]
    public IActionResult AskChangePass(AskChangePassRequest request)
    {
        return HandleResult(_loginService.AskChangePass(request));
    }

    [HttpPost("/change-pass")]
    public IActionResult ChangePass(ChangePassRequest request)
    {
        return HandleResult(_loginService.ChangePass(request));
    }

    private IActionResult HandleResult(Result result)
    {
        return result.IsFailed ? Unauthorized(result) : Ok(result);
    }
}
