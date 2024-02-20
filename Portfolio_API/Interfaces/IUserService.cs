using FluentResults;

namespace Portfolio_API;

public interface IUserService
{
    public Result Login(LoginRequest request);
    public ReadUserDto? GetUserById(int id);
    public Task<List<ReadUserDto>>? GetUsers();
    public Task<Result> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    public Result RegisterUser(CreateUserDto createUserDto);
}
