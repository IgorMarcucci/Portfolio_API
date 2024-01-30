using FluentResults;

namespace Portfolio_API;

public interface IRegisterService
{
    public Result RegisterUser(CreateUserDto createUserDto);

    public Result ActivateAccount(ActiveAccountRequest request);
}

