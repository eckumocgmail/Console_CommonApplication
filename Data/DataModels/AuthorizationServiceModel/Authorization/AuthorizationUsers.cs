using System;
using System.Collections.Generic;
using System.Threading;
public interface APIUsers : APIActiveCollection<UserApi>, DoCheck
{
    string FindByEmail(string email);
}

/// <summary>
/// Служба уровня приложения, содержит пользователей сеансов
/// </summary>
public class AuthorizationUsers: AuthorizationCollection<UserApi>, APIUsers
{

    public AuthorizationUsers(AuthorizationOptions options) : 
        base( options)
    {
    }


    /// <summary>
    /// Добавление обьекта в коллекцию
    /// </summary>
    /// <param name="item"> ссылка на обьект</param>
    /// <returns>ключ доступа к обьекту</returns>
    public override string Put(UserApi item)
    {
        string result = base.Put( item );      
        return result;
    }


    /// <summary>
    /// Сеанс пользователя с заданным EMAIL если 
    /// сеанс ещё активен.
    /// Поиск нужно выполнять независимо от регимтра,
    /// отчистить от непечаемых символов
    /// </summary> 
    public string FindByEmail(string email)
    {
        this.Info($"FindByEmail({email})");
        foreach (UserApi p in GetAll())
        {
            if(p.Account.Email == email)            
                return Find(p);            
        }
        return null;
    }
     
}



/// <summary>
/// Тестируем AuthorizationUsers 
/// </summary>
[Label("Тестирование "+nameof(AuthorizationUsers))]
public class AuthorizationUsersTest: TestingElement
{
    public AuthorizationUsersTest()
    {
    }

    public AuthorizationUsersTest(TestingElement parent) : base(parent)
    {
    }



    public override List<string> OnTest()
    {
        try
        {        
            var options = this.Get<AuthorizationOptions>();
            var users = this.Get<AuthorizationUsers>();

            users.DoCheck(System.DateTimeOffset.Now.ToUnixTimeMilliseconds()).Wait();
            this.Messages.Add(this.GetSuccessMessage<AuthorizationUsers>());

            string key = users.Put(new UserApi());
            if (users.Take(key) == null)
                throw new Exception("Не удалось извлечь контекст пользователя по ключу");
            this.Messages.Add("Контекст пользователей при добавлении в коллекции генерирует уникальный ключ, " +
                "по которому в дальйшем предоставляется доступ к объекту. ");

            users.RemoveAll();
            if (users.Take(key) != null)
                throw new Exception("Контекст пользователей не был отчищен");            
            this.Messages.Add("Контекст пользователей удаляет все ссылки при" +
                " выполнении метода RemoveAll. ");

            key = users.Put(new UserApi());
            Thread.Sleep((int)options.SessionTimeout);
            users.DoCheck(System.DateTimeOffset.Now.ToUnixTimeMilliseconds()).Wait();
            if (users.Take(key) != null)
                throw new Exception("Контекст пользователей не был отчищен");
            this.Messages.Add("Контекст пользователей удаляет устаревшие ссылки " +
                "при выполнении проверки DoCheck(). ");

            this.Messages.Add(this.GetSuccessMessage<AuthorizationUsers>());

        }
        catch (Exception ex)
        {
            string message = GetFailedMessage();
            this.Error(message, ex);
            this.Messages.Add(message);
            throw new Exception(message, ex);
        }
        return Messages;
    }

}