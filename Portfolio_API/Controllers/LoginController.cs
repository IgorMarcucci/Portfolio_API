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

    

    private IActionResult HandleResult(Result result)
    {
        return result.IsFailed ? Unauthorized(result) : Ok(result);
    }
}
