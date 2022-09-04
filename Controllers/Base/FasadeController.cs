using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class FasadeController<T>: BaseController,
    IUserNotificationsService,
    IServiceProvider,
    APIAuthorization
where T : FileEntity
{

    [NotNullNotEmpty][Service] public APIAuthorization authorization { get; set; }
    [NotNullNotEmpty][Service] public IEntityFasade<T> fasade { get; set; }
    [NotNullNotEmpty][Service] public IServiceProvider models { get; set; }
    [NotNullNotEmpty][Service] public IUserNotificationsService notifications { get; set; }

    protected FasadeController(IServiceProvider provider) : base(provider)
    {
        this.Init(provider);
        this.EnsureIsValide();
    }

    public IEnumerable<UserNotificationService> Take()
    {
        return notifications.Take();
    }

    public void Info(string title, string summary)
        => notifications.Info(title, summary);    
    public void Info(string title, string summary, string url)
        => notifications.Info(title, summary, url);    
    public void Success(string message)
        => notifications.Success(message);    
    public void Success(string title, string summary)
        => notifications.Success(title, summary);    
    public void Success(string title, string summary, string url)
        => notifications.Success(title, summary, url);    
    public void Error(string message)
        => notifications.Error(message);    
    public void Error(string title, string summary)
        => notifications.Error(title, summary);    
    public void Error(string title, string summary, string url)    
        => notifications.Error(title, summary, url);
    

    public object GetService(Type serviceType)
        => models.GetService(serviceType);     
    public bool IsSignin()
        => authorization.IsSignin();
    public bool IsUserInRole(string roleName)
    {
        return authorization.IsUserInRole(roleName);
    }

    public bool IsActivated()
    {
        return authorization.IsActivated();
    }

    public bool Signout()
    {
        return authorization.Signout();
    }

    public UserApi Signin(string RFIDLabel)
    {
        return authorization.Signin(RFIDLabel);
    }

    public UserApi Signin(string Email, string Password, bool? IsFront = false)
    {
        return authorization.Signin(Email, Password, IsFront);
    }

    public void Signout(bool? IsFront = false)
    {
        authorization.Signout(IsFront);
    }

    public UserApi Verify(bool? IsFront = false)
    {
        return authorization.Verify(IsFront);
    }

 

    public Task<UserAccount> GetAccountByID(int iD)
    {
        return authorization.GetAccountByID(iD);
    }

    public void RemoveUserWithEmail(string v)
    {
        authorization.RemoveUserWithEmail(v);
    }

    public string GetUserHomeUrl()
    {
        return authorization.GetUserHomeUrl();
    }

   
    public UserApi Signup(string Email, string Password, string Confirmation)
    {
        return authorization.Signup(Email, Password, Confirmation);
    }

    public UserApi Signup(string Email, string Password, string Confirmation, string SurName, string FirstName, string LastName, DateTime Birthday, string Tel)
    {
        return authorization.Signup(Email, Password, Confirmation, SurName, FirstName, LastName, Birthday, Tel);
    }

    public bool HasUserWithEmail(string email)
    {
        return authorization.HasUserWithEmail(email);
    }

    public bool HasUserWithActivationKey(string activationKey)
    {
        return authorization.HasUserWithActivationKey(activationKey);
    }

    public bool HasUserWithTel(string tel)
    {
        return authorization.HasUserWithTel(tel);
    }

    public UserApi GetUserByEmail(string email)
    {
        return authorization.GetUserByEmail(email);
    }

    public UserApi GetUserByTel(string tel)
    {
        return authorization.GetUserByTel(tel);
    }

    public string GetHashSha256(string password)
    {
        return authorization.GetHashSha256(password);
    }

    public string GenerateRandomPassword(int length)
    {
        return authorization.GenerateRandomPassword(length);
    }

    public string GenerateActivationKey(int length)
    {
        return authorization.GenerateActivationKey(length);
    }

    public void RestorePasswordByEmail(string email)
    {
        authorization.RestorePasswordByEmail(email);
    }
}
