using MimeKit;

namespace Portfolio_API;

public class MessageModel
{
    public List<MailboxAddress> Recipient { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public MessageModel(IEnumerable<string> recipient, string subject, string content)
    {
        Recipient = new List<MailboxAddress>();
        Recipient.AddRange(recipient.Select(d => new MailboxAddress(d, d)));
        Subject = subject;
        Content = content;
    }
}
