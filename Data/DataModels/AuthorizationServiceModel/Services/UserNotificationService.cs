using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
/// <summary>
/// Предоставляет функции вывода уведомлений на экран пользователя
/// </summary>
public interface IUserNotificationsService
{
    /// <summary>
    /// Возвращает все сообщения, при этом извлекает их из памяти
    /// </summary>    
    IEnumerable<UserNotificationService> Take();

    /// <summary>
    /// Регистрирует уведомление в сеансе пользователя
    /// </summary>
    /// <param name="title"></param>
    void Info(string title);
    void Info(string title, string summary);
    void Info(string title, string summary, string url);
    void Success(string message);
    void Success(string title, string summary);
    void Success(string title, string summary, string url);
    void Error(string message);
    void Error(string title, string summary);
    void Error(string title, string summary, string url);
}
public class UserNotificationService: IUserNotificationsService
{
    /// <summary>
    /// Один из вариантов
    /// </summary>
    public string Type { get; set; }
    public DateTime Created { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string URL { get; set; }

    public IEnumerable<UserNotificationService> Take() => new List<UserNotificationService>();
    public void Info(string title)
    {
    }

    public void Info(string title, string summary)
    {
    }

    public void Info(string title, string summary, string url)
    {
    }

    public void Success(string message)
    {
    }

    public void Success(string title, string summary)
    {
    }

    public void Success(string title, string summary, string url)
    {
    }

    public void Error(string message)
    {
    }

    public void Error(string title, string summary)
    {
    }

    public void Error(string title, string summary, string url)
    {
    }
}

/// <summary>
/// Служба вывода уведомлений в интерфейс пользователя
/// </summary>
public class UserNotificationsService : IUserNotificationsService
{
    /// <summary>
    /// Очередь уведомлений
    /// </summary>
    public ConcurrentQueue<UserNotificationService> Messages =
            new ConcurrentQueue<UserNotificationService>();


    public UserNotificationsService()
    {
    }

    public IEnumerable<UserNotificationService> Take()
    {
        lock (Messages)
        {
            var items = Messages.ToArray();
            Messages.Clear();
            return new List<UserNotificationService>(items);
        }
    }

    public void Info(string message)
    {
        Messages.Enqueue(new UserNotificationService()
        {
            Type = "info",
            Title = message,
            Created = DateTime.Now
        });
    }


    /// <summary>
    /// Уведомление об успешном выполнении операции
    /// </summary>
    /// <param name="message">текст сообщения</param>
    public void Success(string message)
    {
        Messages.Enqueue(new UserNotificationService()
        {
            Type = "success",
            Title = message,
            Created = DateTime.Now
        });
    }

    public void Error(string message)
    {
        Messages.Enqueue(new UserNotificationService()
        {
            Type = "danger",
            Title = message,
            Created = DateTime.Now
        });
    }

    public void Info(string title, string summary)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Info(string title, string summary, string url)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }


    /// <summary>
    /// Уведомление об успешном выполнении операции
    /// </summary>
    /// <param name="title">текст сообщения</param>
    /// <param name="summary">детальная информация</param>
    public void Success(string title, string summary)
    {
        Messages.Enqueue(new UserNotificationService()
        {
            Type = "success",
            Title = title,
            Summary = summary,
            Created = DateTime.Now
        });
    }


    /// <summary>
    /// Уведомление об успешном выполнении операции
    /// </summary>
    /// <param name="title">текст сообщения</param>
    /// <param name="summary">детальная информация</param>
    /// <param name="summary">ссылка документ</param>
    public void Success(string title, string summary, string url)
    {
        Messages.Enqueue(new UserNotificationService()
        {
            Type = "success",
            Title = title,
            Summary = summary,
            URL = url,
            Created = DateTime.Now
        });
    }

    public void Error(string title, string summary)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Error(string title, string summary, string url)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
 