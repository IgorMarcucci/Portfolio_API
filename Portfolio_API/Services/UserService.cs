using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class UserService : IUserService
{
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;

    public UserService(UserManager<IdentityUser<int>> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<ReadUserDto>>? GetUsers()
    {
        List<IdentityUser<int>> users = await _userManager.Users.ToListAsync();
        if (users == null || !users.Any())
            return null;
        
        List<ReadUserDto> usersDto = _mapper.Map<List<ReadUserDto>>(users);
        foreach (var user in usersDto)
        {
            var identityUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (identityUser == null)
                continue;
            
        }
        return usersDto;
    }
    public async Task<Result> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
    {
        IdentityUser<int>? user = await _userManager.FindByIdAsync(id.ToString());
        if (user != null)
        {
            _mapper.Map(updateUserDto, user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Result.Ok();
        }
        return Result.Fail("Falha ao confirmar email!");
    }

}
