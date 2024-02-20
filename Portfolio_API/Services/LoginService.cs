using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Portfolio_API;

public class LoginService : ILoginService
{
    private IMapper _mapper;
    private ITokenService _tokenService;
    private IEmailService _emailService;
    private SignInManager<IdentityUser<int>> _signInManager;
    private IConfiguration _configuration;

    public LoginService(ITokenService tokenService,
        SignInManager<IdentityUser<int>> signInManager,
        IEmailService emailService,
        IMapper mapper,
        IConfiguration configuration)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _emailService = emailService;
        _mapper = mapper;
        _configuration = configuration;
    }

    
}
