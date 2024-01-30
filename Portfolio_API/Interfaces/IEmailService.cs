using Microsoft.AspNetCore.Identity;

namespace Portfolio_API;

public interface IEmailService
{
    public void SendConfirmationEmailAccount(IdentityUser<int> user, string subject, string code, string pass);
    public void SendPasswordResetEmail(IdentityUser<int> user, string subject, string code);
}
