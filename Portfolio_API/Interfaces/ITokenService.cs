using Microsoft.AspNetCore.Identity;

namespace Portfolio_API;

public interface ITokenService
{
    public TokenModel CreateToken(IdentityUser<int>? user, string jwtSecret);
}