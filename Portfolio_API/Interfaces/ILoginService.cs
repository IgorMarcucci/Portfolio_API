using FluentResults;

namespace Portfolio_API;
public interface ILoginService
{
    public Result LoginUser(LoginRequest request);
    public Result AskPasswordReset(AskPassResetRequest request);
    public Result ResetPassword(DoPassResetRequest request);
    public ReadUserDto? GetUserById(int id);
}
