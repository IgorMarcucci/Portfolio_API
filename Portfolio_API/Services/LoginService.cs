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

    public Result Login(LoginRequest request)
    {

        string jwtPass = _configuration.GetValue<string>("JwtPass")
            ?? throw new ArgumentNullException("JwtPass not found");

        var identityResult = _signInManager
            .PasswordSignInAsync(request.Email, request.Password, false, false);
        if (identityResult.Result.Succeeded)
        {
            IdentityUser<int>? identityUser = _signInManager.
                UserManager.Users.FirstOrDefault(u => u.Email
                == request.Email);
            TokenModel? token = _tokenService.CreateToken(identityUser, jwtPass);
            return Result.Ok().WithSuccess(token.Value);
        }
        return Result.Fail("Login falhou");
    }

    public Result AskChangePass(AskChangePassRequest request)
    {
        IdentityUser<int> identityUser = GetUserByEmail(request.Email);

        if (identityUser != null)
        {
            string recoveryCode = _signInManager
                .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
            _emailService.SendPasswordResetEmail(identityUser,
                "Recuperar senha", recoveryCode);
            return Result.Ok();
        }
        return Result.Fail("Falha ao solicitar redefinição");
    }

    public Result ChangePass(ChangePassRequest request)
    {
        IdentityUser<int>? identityUser = GetUserByEmail(request.Email);

        IdentityResult identityResult = _signInManager.UserManager
            .ResetPasswordAsync(identityUser, request.Token, request.Password)
            .Result;
        if (identityResult.Succeeded) return Result.Ok()
                .WithSuccess("Senha redefinida com sucesso!");
        return Result.Fail("Houve um erro na operação");
    }

    private IdentityUser<int>? GetUserByEmail(string email)
    {
        return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
    }

    public ReadUserDto? GetUserById(int id)
    {
        IdentityUser<int>? identityUser = _signInManager.
                UserManager.Users.FirstOrDefault(u => u.Id == id);

        if (identityUser == null)
            return null;

        ReadUserDto readUserDto = _mapper.Map<ReadUserDto>(identityUser);

        return readUserDto;
    }
}
