
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using static Api.Utils;
using System;
using System.IO;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
/// <summary>
/// Расширение для регистрации сервисов Email
/// </summary>
public static class EmailExtensions
{

    /// <summary>
    /// Расширение для регистрации сервисов Email
    /// </summary>
    public static IServiceCollection AddEmail(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configurationRoot)
    {

        services.AddSingleton(typeof(EmailOptions), sp => {

            WriteLine("Считываем конфигурацию электронной почты");
            var options = configurationRoot.GetSection(typeof(EmailOptions).GetTypeName()).Get<EmailOptions>();
            if (options == null)
            {
                options = new EmailOptions();
                WriteLine($"\n\n" +
                    $"(!) Дополните appsettings.json параметром: \n");
                WriteLine($"\"EmailOptions\": " + new EmailOptions().ToJsonOnScreen());
            }
            return options;
        });
        services.AddSingleton<UserEmailService>();
        services.AddSingleton<IEmailService, UserEmailService>();
        return services;
    }
}

public class UserEmailService : IEmailService
{
    protected EmailOptions _options;

    public UserEmailService(EmailOptions options)
    {
        _options = options;
    }

    public void SendEmail(string email, string subject, string message)
    {
        using (SmtpClient smtp = new SmtpClient(_options.SmtpHost, _options.SmtpPort))
        {
            var emailMessage = new System.Net.Mail.MailMessage();

            emailMessage.From = new MailAddress(this._options.EmailAddress);
            emailMessage.Sender = new MailAddress(this._options.EmailAddress);
            
            emailMessage.To.Add(email);
            emailMessage.Subject = subject;
            emailMessage.Body = message;

            smtp.Send(emailMessage);
        }
    }
}


/// <summary>
/// 
/// </summary>
public class EmailOptions
{
    public string EmailName;
    public string EmailAddress;
    public string EmailPassword;
    public string SmtpHost;
    public int SmtpPort;
    public string PopHost;
    public int PopPort;
    public EmailOptions()
    {
        this.EmailName = "EcKuMoC";
        this.EmailAddress = "kba-2021@mail.ru";
        this.EmailPassword = "eckumoc1423";
        this.SmtpHost = "smtp.mail.ru";
        this.SmtpPort = 587;
        this.PopHost = "pop.mail.ru";
        this.PopPort = 995;
    }

    public static EmailOptions Copy(EmailOptions options)
    {
        var p = new EmailOptions();
        p.EmailName = options.EmailName;
        p.EmailAddress = options.EmailAddress;
        p.EmailPassword = options.EmailPassword;
        p.SmtpHost = options.SmtpHost;
        p.SmtpPort = options.SmtpPort;
        p.PopHost = options.PopHost;
        p.PopPort = options.PopPort;
        return p;
    }
    public void CopyTo(EmailOptions options)
    {

        options.EmailName = this.EmailName;
        options.EmailAddress = this.EmailAddress;
        options.EmailPassword = this.EmailPassword;
        options.SmtpHost = this.SmtpHost;
        options.SmtpPort = this.SmtpPort;
        options.PopHost = this.PopHost;
        options.PopPort = this.PopPort;

    }


}
/// <summary>
/// 
/// </summary>
public interface IEmailService
{
    void SendEmail(string email, string subject, string message);
};




/// <summary>
/// Сервис умеет отправлять электронную почту и считывать входящие письма
/// </summary>
public class EmailService : IEmailService
{
    protected EmailOptions _options;

    public EmailService(EmailOptions options)
    {
        _options = options;
    }

    public void Recieve()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }


    /// <summary>
    /// Отправка сообщения по электронной почте
    /// </summary> 
    public void SendEmail(string email, string subject, string message)
    {

    }
}
    /*
    /// <summary>
    /// Отправка сообщения по электронной почте с прикреплёнными файлами
    /// </summary> 
    public void SendEmail(string email, string subject, string message, 
                            ImageResource[] resources)
    {
        using (var smtp = new MailKit.Net.Smtp.SmtpClient())
        {
            smtp.ServerCertificateValidationCallback = (s, c, h, e) =>
            {
                return true;
            };

            smtp.Connect(_options.smtpHost, _options.smtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.emailAddress, _options.emailPassword);
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_options.emailName, _options.emailAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            var builder = new BodyBuilder();
                
            builder.TextBody = message;
            if (resources != null)
            {
                foreach(var resource in resources)
                {
                    System.IO.File.WriteAllBytes(resource.Name, resource.Data);
                    builder.Attachments.Add(resource.Name);
                }
            }                             
            emailMessage.Body = builder.ToMessageBody();
               
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
        }
    }


    /// <summary>
    /// Получение входящих сообщений
    /// </summary>
    public void Recieve()
    {
        using (var client = new Pop3Client())
        {                
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect(_options.popHost, _options.popPort);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_options.emailAddress, _options.emailAddress );
            for (int i = 0; i < client.Count; i++)
            {
                MimeMessage message = client.GetMessage(i);                    
            }
            client.Disconnect(true);
        }
    }
} */