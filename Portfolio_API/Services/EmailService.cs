using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace Portfolio_API;

public class EmailService : IEmailService
{
    private IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendConfirmationEmailAccount(IdentityUser<int> user, string subject, string code, string pass)
    {
        string? webApplicationUrl = _configuration["WebApplicationUrl"];

        string content = 
            $"Olá {user.UserName},\n\n" + 
            $"Você foi convidado para se cadastrar na ferramenta web de custos.\n\n" + 
            $"Para se cadastrar, clique no link abaixo:\n\n" + 
            $"{webApplicationUrl}/active?UserId={user.Id}&ActivationCode={code}" + 
            $"Seu usuário é: {user.UserName}\n\n" + 
            $"Sua senha é: {pass}\n\n";

        MessageModel message = new MessageModel(new[] { user.Email }, subject, content);

        MimeMessage emailMessage = CreateEmailBody(message);
        Send(emailMessage);
    }

    public void SendPasswordResetEmail(IdentityUser<int> user, string subject, string code)
    {
        string? frontEndUrl = _configuration["FrontendUrl"];

        string content = $"Alteração de senha - ferramenta web de custos\n\n" + 
            $"Olá {user.UserName},\n\n" + 
            $"Você solicitou a recuperação de senha da ferramenta web de custos.\n\n" + 
            $"Para recuperar sua senha, clique no link abaixo:\n\n" + 
            $"{frontEndUrl}/changepass?token={code}&email={user.Email}" + 
            $"Seu usuário é: {user.UserName}\n\n";

        MessageModel message = new MessageModel(new[] { user.Email }, subject, content);

        MimeMessage emailMessage = CreateEmailBody(message);
        Send(emailMessage);
    }

    private void Send(MimeMessage message)
    {
        using (var client =  new SmtpClient())
        try
        {
            client.Connect(_configuration.GetValue<string>("SmtpServer"),
                _configuration.GetValue<int>("SmtpPort" ), true);
            client.AuthenticationMechanisms.Remove("XOUATH2");
            client.Authenticate(_configuration.GetValue<string>("SmtpEmail"),
                _configuration.GetValue<string>("SmtpPassword"));
            client.Send(message);
        }
        catch
        {
            throw;
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    } 

    private MimeMessage CreateEmailBody(MessageModel message)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(
                _configuration.GetValue<string>("SmtpEmail"),
                _configuration.GetValue<string>("SmtpEmail")));
        mimeMessage.To.AddRange(message.Recipient.Select(r => (MimeKit.InternetAddress)r));
        mimeMessage.Subject = message.Subject;
        mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message.Content
        };

        return mimeMessage;
    }
}
