using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Portfolio_API;

public class RegisterService : IRegisterService
{
    private IMapper _mapper;
    private IEmailService _emailService;
    private UserManager<IdentityUser<int>> _userManager;
    public RegisterService(IMapper mapper, IEmailService emailService,
            UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }
    
    public Result RegisterUser(CreateUserDto createUserDto)
    {
        IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(createUserDto);

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

    public Result ActivateAccount(ActiveAccountRequest request)
    {
        IdentityUser<int>? identityUser = _userManager.Users
            .FirstOrDefault(u => u.Id == request.UserId);

        if (identityUser != null)
        {
            IdentityResult identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
        }

        return Result.Fail("Falha ao ativar conta de usuário");
    }
    
}
