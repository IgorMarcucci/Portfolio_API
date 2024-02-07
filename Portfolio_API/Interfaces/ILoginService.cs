using FluentResults;

namespace Portfolio_API;
public interface ILoginService
{
    public Result Login(LoginRequest request);
    public Result AskChangePass(AskChangePassRequest request);
    public Result ChangePass(ChangePassRequest request);
    public ReadUserDto? GetUserById(int id);
}
