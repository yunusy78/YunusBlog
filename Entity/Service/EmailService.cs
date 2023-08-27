using Entity.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Entity.Service;

public class EmailService: IEmailSender

{
    public string SendGridSecret { get; set; }

    public EmailService(IConfiguration _config)
    {
        SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
    }
    
  
    
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var emailToSend = new MimeMessage();
        emailToSend.From.Add(MailboxAddress.Parse("globetrotter.org.no@gmail.com"));
        emailToSend.To.Add(MailboxAddress.Parse(email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = htmlMessage
        };
        using (var emailClient = new SmtpClient())
        {
            emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            emailClient.Authenticate("globetrotter.org.no@gmail.com", "zdwvxgqvtqheqmfi");
            emailClient.Send(emailToSend);
            emailClient.Disconnect(true);
        }
        return Task.CompletedTask;
    }
    
    


    
}