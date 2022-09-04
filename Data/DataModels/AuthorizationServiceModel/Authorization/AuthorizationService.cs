


using ApplicationDb.Entities;


using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public interface APIRegistration
{
    UserApi Signup(string Email, string Password, string Confirmation);
    UserApi Signup(string Email, string Password, string Confirmation,
                string SurName, string FirstName, string LastName, DateTime Birthday, string Tel);
    bool HasUserWithEmail(string email);
    bool HasUserWithActivationKey(string activationKey);
    bool HasUserWithTel(string tel);
    UserApi GetUserByEmail(string email);
    UserApi GetUserByTel(string tel);
    string GetHashSha256(string password);
    string GenerateRandomPassword(int length);
    string GenerateActivationKey(int length);
    void RestorePasswordByEmail(string email);
}

public interface APIAuthorization : APIRegistration
{
    bool IsSignin();
    bool IsUserInRole(string roleName);
    bool IsActivated();
    bool Signout();
    UserApi Signin(string RFIDLabel);
    UserApi Signin(string Email, string Password, bool? IsFront = false);
    void Signout(bool? IsFront = false);
    UserApi Verify(bool? IsFront = false);
    Task<UserAccount> GetAccountByID(int iD);
    void RemoveUserWithEmail(string v);
    string GetUserHomeUrl(); 
}

/// <summary>
/// Служба транспортного уровня, выполняет авторизацию, регистрацию и идентификацияю пользователей
/// </summary>
public class AuthorizationService: UserRegistrationService, APIAuthorization
{
    public AuthorizationService(IServiceProvider provider) : base(provider)
    {
        this._provider = provider;
    }



    private UserApi FindUserByEmail(string Email)
    {
        UserApi current = (from user
                        in _db.Users
                            .Include(a => a.Account)

                            .Include(a => a.Settings)
                            .Include(a => a.Person)
                            .Include(a => a.Role)
                            .Include(a => a.UserGroups)
                           where user.Account.Email == Email
                           select user).FirstOrDefault();
        if (current != null)
        {
            BusinessResource resource = current.Role;
            while (resource.ParentID != null)
            {
                resource.Parent = _db.BusinessResources.Find(resource.ParentID);
                resource = resource.Parent;
            }

        }

        return current;
    }




    private TimePoint GetTodayCalendar()
    {
        DateTime p = DateTime.Now;

        return new TimePoint()
        {
            Day = p.Day,
            Quarter = p.Month < 4 ? 1 : p.Month < 7 ? 2 : p.Month < 10 ? 3 : 4,
            Month = p.Month,
            Week = 1,
            Year = p.Year,
            Timestamp = (long)((new DateTime(p.Year, p.Month, p.Day) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds)
        };
    }
    [Service] public IHttpContextAccessor _accessor {get;set;}
    [Service] public HttpCookieManager _cookieManager { get; set; } = new HttpCookieManager(null);

    [Service] public APIUsers _users { get; set; }


    /// <summary>
    /// Проверка выполнения процедуры авторизации
    /// </summary>
    /// <returns></returns>
    public bool IsSignin()
    {
        this.Init(_provider);
        if (_options.LogginAuth)
            this.Info("IsSignin");

        string SecretKey = _cookieManager.GetCookie(_options.UserCookie);
        if (SecretKey == null)
        {
            if (_options.LogginAuth)
                this.Info("IsSignin = false");
            return false;
        }
        else
        {
            UserApi user = _users.Take(SecretKey);
            if (user == null)
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _accessor.HttpContext.Response.Cookies.Delete(_options.UserCookie);
                }
                if (_options.LogginAuth)
                    this.Info("IsSignin = false");
                return false;
            }
            else
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _cookieManager.SetCookie(_options.UserCookie, SecretKey);
                }
                if (_options.LogginAuth)
                    this.Info("IsSignin = true");
                return true;
            }
        }

    }

  

    /// <summary>
    /// Авторизация пользователя в системе
    /// </summary>
    /// <param name="Email">электронный адрес</param>
    /// <param name="Password">пароль</param>
    /// <param name="IsFront"> </param>
    public UserApi Signin(string Email, string Password, bool? IsFront = false)
    {
        this.EnsureIsValide();
        if (_options.LogginAuth)
            this.Info("Signin");

        lock (_users)
        {

            if (IsSignin())
            {
                UserApi user = Verify();
                if (user != null && _users.Has(user.SecretKey))
                {
                    _users.Remove(user.SecretKey);
                    _db.SaveChanges();
                }
                this.Signout();
            }


            UserApi current = FindUserByEmail(Email.ToLower());
            if (current == null || GetHashSha256(Password) != current.Account.Hash)
            {
                if (IsFront == false)
                {

                    throw new Exception("Учётные данные не зарегистрированы");
                }
                else
                {
                    _accessor.HttpContext.Response.Redirect(_options.LoginPagePath);
                }
            }
            else
            {
                current.Context = new UserApiContext();
                current.Settings.ColorTheme = current.Settings.ColorTheme == null ? "Dark" : "Light";
                _db.SaveChanges();
                current.LoginCount = current.LoginCount + 1;
                current.Groups = (from g in _db.Groups where (from p in current.UserGroups select p.GroupID).Contains(g.ID) select g).ToList();
                var userGroupIDs = (from p in current.Groups select p.ID).ToList();
                //current.Role = (from p in _db.GroupsBusinessFunctions.Include(b => b.BusinessFunction) where userGroupIDs.Contains(p.GroupID) select p.BusinessFunction).ToList();
                _db.SaveChanges();

                current.Groups = (from grs
                                    in _db.Groups
                                  where (from ug in current.UserGroups select ug.GroupID).Contains(grs.ID)
                                  select grs).ToList();
                string currentKey = _users.FindByEmail(Email);
                current.SecretKey = String.IsNullOrWhiteSpace(currentKey) ?
                    _users.Put(current) : currentKey;
                _users.DoCheck(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                current.IsActive = true;
                _db.SaveChanges();


                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _cookieManager.SetCookie(_options.UserCookie, current.SecretKey);
                    var val = _cookieManager.GetCookie(_options.UserCookie);
                }
                current.EnsureIsValide();

            }
            return current;
        }

    }

    /// <summary>
    /// Метод выхода пользователя из сеанса
    /// </summary>
    public void Signout(bool? IsFront = false)
    {
        if (_options.LogginAuth)
            this.Info("Signout");
        UserApi user = Verify(IsFront);
        lock (_users)
        {
            if (user != null && _users.Has(user.SecretKey))
            {
                _users.Remove(user.SecretKey);
                user.IsActive = false;
                user.Update();
                _db.SaveChanges();
            }
            if (IsFront == false)
            {
                _accessor.HttpContext.Response.Redirect(_options.LoginPagePath);
            }

        }
    }





    public IDictionary<string, object> GetSession(HttpContext httpContext) =>
        _users.GetUserSession(_cookieManager.GetCookie(_options.UserCookie));



    /// <summary>
    /// Идентификация пользователя в системе
    /// </summary>
    /// <returns>ссылка на обьект сеанса</returns>
    public UserApi Verify(bool? IsFront = false)
    {
        if (_options.LogginAuth)
            this.Info("Verify");

        string SecretKey = _cookieManager.GetCookie(_options.UserCookie);
        if (SecretKey == null)
        {
           
            return null;
        }
        else
        {
            UserApi user = _users.Take(SecretKey);
            if (user == null)
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _accessor.HttpContext.Response.Cookies.Delete(_options.UserCookie);
                    if (IsFront == false)
                    {
                        _accessor.HttpContext.Response.Redirect(_options.LoginPagePath);
                    }
                }
            }
            else
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _cookieManager.SetCookie(_options.UserCookie, SecretKey);
                }
            }
            return user;
        }
    }





    /// <summary>
    /// Получечние текущего времени в милисекундах
    /// </summary>
    /// <returns></returns>
    private static long GetTimestamp()
    {
        return (long)(((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0))).TotalMilliseconds);
    }







    /// <summary>
    /// Метод получения атрибутов сеанса
    /// </summary>
    /// <returns></returns>
    public ConcurrentDictionary<string, object> Session()
    {
        if (_options.LogginAuth)
            this.Info("Session");
        string SecretKey = null;
        _accessor.HttpContext.Request.Cookies.TryGetValue(_options.UserCookie, out SecretKey);
        if (SecretKey == null)
        {
            return null;
        }
        else
        {
            ConcurrentDictionary<string, object> session = _users.GetUserSession(SecretKey);
            if (session == null)
            {
                _accessor.HttpContext.Response.Cookies.Delete(_options.UserCookie);
            }
            else
            {
                if (_accessor.HttpContext.Response.HasStarted == false)
                {
                    _cookieManager.SetCookie(_options.UserCookie, SecretKey);
                }

            }
            return session;
        }
    }



    /// <summary>
    /// Проверка принадлежности пользователя к роли
    /// </summary>
    /// <param name="roleName">наменование роли</param>
    /// <returns></returns>
    public bool InRole(string roleName)
    {
        if (_options.LogginAuth)
            this.Info("InRole");
        UserApi user = this.Verify();
        if (user == null)
        {
            return false;
        }
        else
        {
            BusinessResource prole = user.Role;
            while (prole != null)
            {
                if (prole.Code == roleName)
                {
                    return true;
                }
                if (prole.ParentID == null)
                {
                    break;
                }
                else
                {
                    if (prole.ParentID == prole.ID)
                    {
                        break;
                    }
                    prole = _db.BusinessResources.Find((int)prole.ParentID);
                }
            }
            return false;
        }
    }


    /// <summary>
    /// Проверка активации учетной записи
    /// </summary>
    /// <returns></returns>
    public bool IsActivated()
    {
        this.Info("Проверяем активацию электронной почты");
        UserApi user = Verify();
        if (user == null)
        {
            return false;
        }
        else
        {
            return _db.Accounts.Find(user.Account.ID).Activated != null;
        }
    }


    /// <summary>
    /// Авторизация по радиометки
    /// </summary>
    public UserApi Signin(string RFIDLabel)
    {
        if (_options.LogginAuth)
            this.Info("Signin");
        if (IsSignin())
        {
            Signout();
        }

        UserApi current = (from user
                        in _db.Users
                            .Include(a => a.Account)
                            .Include(a => a.Settings)
                            .Include(a => a.Person)
                            .Include(a => a.Role)
                            .Include(a => a.UserGroups)
                           where user.Account.RFID == RFIDLabel
                           select user).FirstOrDefault();
        if (current == null)
        {
            throw new Exception("Учетные данные не зарегистрированы");
        }
        else
        {
            current.Groups = (from grs
                                in _db.Groups
                              where (from ug in current.UserGroups select ug.GroupID).Contains(grs.ID)
                              select grs).ToList();
            string currentKey = _users.Find(current);
            current.SecretKey = currentKey != null ? currentKey : _users.Put(current);
            current.IsActive = true;
            long timestamp = TimeUtils.GetTodayBeginTime();
            _db.SaveChanges();
            _db.LoginFacts.Add(new LoginEvent()
            {
                Created = DateTime.Now,
                UserID = current.ID,
                ProcessID = Process.GetCurrentProcess().Id,
                HostID = 1,
                AppID = 1,
                ThreadID = 1,
                RequestID = 1,
                T = (from cal in _db.Calendars where cal.Timestamp == timestamp select cal).First()
            });
            _db.SaveChanges();
            _cookieManager.SetCookie(_options.UserCookie, current.SecretKey);
            return current;
        }

    }

    public async Task<UserAccount> GetAccountByID(int iD)
    {
        await Task.CompletedTask;
        return _db.Accounts.Where(a => a.ID == iD).FirstOrDefault();
    }

    public bool IsUserInRole(string code)
    {
        this.Info($"Проверяем права: код: {code} ... ");
        if (IsSignin())
        {
            var userApi = this.Verify();
            BusinessResource prole = userApi.Role;
            while (prole != null)
            {
                if (prole.Code == code)
                    return true;
                if (prole.ParentID != null)
                {
                    prole.Parent = GetRoleById((int)prole.ParentID);
                }
                prole = prole.Parent;
            }
            return false;
        }
        else
        {
            _accessor.HttpContext.Response.Redirect(_options.LoginPagePath);
            return false;
        }
    }

    private BusinessResource GetRoleById(int parentID)
        => _db.BusinessResources.Find(parentID);

    public void RemoveUserWithEmail(string Email)
    {
        this.Info("Удаляю учетную запись ... ");
        UserApi user = FindUserByEmail(Email);
        if (user != null)
        {
            _db.Accounts.Remove(_db.Accounts.Find(user.AccountID));
            _db.Settings.Remove(_db.Settings.Find(user.SettingsID));
            _db.Persons.Remove(_db.Persons.Find(user.PersonID));
            _db.SaveChanges();
        }
    }

    public bool Signout()
    {
        this.Info("Signout() ... ");
        _accessor.HttpContext.Response.Redirect(_options.LogoutPagePath);
        return true;
    }

    public string GetUserHomeUrl() => _options.HomePagePath;

    public IDictionary<string, object> GetSession()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
     


    //public UserMessagesService _messages { get; }

    //private readonly StatisticsService _statistics;



    /*
        public AuthorizationService(  IServiceProvider serviceProvider): base(serviceProvider)
        {
            this.Info($"AuthorizationService()");
            //this.Init(serviceProvider);
        }



        public IDictionary<string, object> GetSession()
        {
            throw new NotImplementedException($"{GetType().GetTypeName()}");
        }*/
}

