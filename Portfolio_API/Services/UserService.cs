using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<UserModel> _userManager;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly IConfiguration _configuration;

    public UserService(IMapper mapper, UserManager<UserModel> userManager,
        IEmailService emailService, ITokenService tokenService,
        SignInManager<UserModel> signInManager,
        IConfiguration configuration)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<List<ReadUserDto>>? GetUsers()
    {
         List<UserModel> users = await _userManager.Users
                .Include(u => u.Jobs)
                .ToListAsync();

        if (users == null || !users.Any())
            return null;

        List<ReadUserDto> usersDto = _mapper.Map<List<ReadUserDto>>(users);
        return usersDto;
    }

    public async Task<Result> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return Result.Fail("User not found!");
        }

        _mapper.Map(updateUserDto, user);
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded ? Result.Ok() : Result.Fail("Failed to confirm email!");
    }

    public Result Login(LoginRequest request)
    {

        string jwtPass = _configuration.GetValue<string>("JwtPass")
            ?? throw new ArgumentNullException("JwtPass not found");

        var identityResult = _signInManager
            .PasswordSignInAsync(request.Email, request.Password, false, false);
        if (identityResult.Result.Succeeded)
        {
            UserModel? identityUser = _signInManager.
                UserManager.Users.FirstOrDefault(u => u.Email
                == request.Email);
            TokenModel? token = _tokenService.CreateToken(identityUser, jwtPass);
            return Result.Ok().WithSuccess(token.Value);
        }
        return Result.Fail("Login falhou");
    }

    public ReadUserDto? GetUserById(int id)
    {
        UserModel? identityUser = _signInManager.
                UserManager.Users.FirstOrDefault(u => u.Id == id);

        if (identityUser == null)
            return null;

        ReadUserDto readUserDto = _mapper.Map<ReadUserDto>(identityUser);

        return readUserDto;
    }

    public Result RegisterUser(CreateUserDto createUserDto)
    {
        UserModel identityUser = _mapper.Map<UserModel>(createUserDto);

        Task<IdentityResult> result = _userManager.CreateAsync(identityUser, createUserDto.Password);

        if (result.Result.Succeeded)
        {
            string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
            var encodedCode = HttpUtility.UrlEncode(code);

            _emailService.SendConfirmationEmailAccount(identityUser,
                    "Link de Ativação", encodedCode, createUserDto.Password);
            
            return Result.Ok();
        }
        else
        {
            return Result.Fail("Erro ao criar usuário");
        }
    }

}
