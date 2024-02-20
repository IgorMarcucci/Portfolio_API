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
    
    
}
