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

    

}
