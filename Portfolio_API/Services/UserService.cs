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
        var users = await _userManager.Users.ToListAsync();
        return users?.Count > 0 ? _mapper.Map<List<ReadUserDto>>(users) : null;
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

}
