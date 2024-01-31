using FluentResults;

namespace Portfolio_API;

public interface IUserService
{
    public Task<List<ReadUserDto>>? GetUsers();
    public Task<Result> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
}
