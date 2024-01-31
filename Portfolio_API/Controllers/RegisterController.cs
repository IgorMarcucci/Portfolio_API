using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API;

[Route("[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private IConfiguration _configuration;
    private RegisterService _registerService;

    public RegisterController(RegisterService registerService, IConfiguration configuration)
    {
        _registerService = registerService;
        _configuration = configuration;
    }

    [HttpPost]
    [Authorize()]
    public IActionResult RegisterUser(CreateUserDto createUserDto)
    {
        Result result = _registerService.RegisterUser(createUserDto);
        if (result.IsFailed) return StatusCode(500);
        return Ok(result);
    }

    [HttpGet("/active")]
    public IActionResult ActiveAccount([FromQuery] ActiveAccountRequest request)
    {

        string frontendUrl = _configuration.GetValue<string>("FrontendUrl") ?? "https://www.supplyflow.com.br/#";

        Result result = _registerService.ActivateAccount(request);
        if (result.IsFailed) return StatusCode(500);

        var content = "<html><body><h1>Email confirmado com sucesso</h1>" +
            $"<a href=\"{frontendUrl}\">" +
            "Acesse a plataforma</a></body></html>";

        return new ContentResult()
        {
            Content = content,
            ContentType = "text/html",
        };
    }

}
