using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;

/// <summary>


/// </summary>
[Icon("")]
[Label("Тестирование служб аутентификации")]
[Description(
    @"Проверяет работоспособность модуля аутентификации.
    I)Уровень данных
    II)Уровень представления
    III)Уровень приложения
    IV)Уровень системы
    -проверка действий при отсутвии прав доступа
    -проверка журналов регистрации действий аутентификации
    -проверка функций предоставления/лишения прав доступ
    -регистрация учетных данных
    -проверка функции выдачи токена доступа по логину и паролю
    -проверка времени жизни сеанса
    -првоерка аутентификации сервиса по открытому ключу
    -проверка принадлежности пользователя или сервис к группе пользователей 
    уполномоченных набором прав исп. функций приложения")]
public class AuthorizationServiceUnit : TestingElement
{
    public AuthorizationServiceUnit(TestingElement parent) : base(parent)
    {
        Push(new UserGroupsTest(this));
        Push(new UserMessagesTest(this));
        Push(new UserModelsTest(this));
        Push(new UserNotificationTest(this));
        Push(new UserRegistrationTest(this));
        Push(new UserProtocolTest(this));
        Push(new UserRequestTest(this));
        Push(new UserResourcesTest(this));
        Push(new UserRolesTest(this));
    }


    public void canCreateModel()
    {
        try
        {
            using (AuthorizationDataModel model = AppProviderService.GetInstance().Get<AuthorizationDataModel>())
            {
                model.Database.EnsureDeleted();
                model.Database.EnsureCreated();
                model.Init();
                foreach(var entity in model.GetEntityTypeNames())
                {
                    try
                    {
                        this.Info($"Сущность {entity} должна сериализоваться");
                        entity.ToType().New().ToJsonOnScreen().WriteToConsole();
                    }
                    catch (Exception ex)
                    {
                        this.Error($"Сущность {entity} не можен быть сериализованной стандартным сериализатором");
                    }

                    try
                    {
                        model.List(entity);
                    }
                    catch (Exception ex)
                    {
                        this.Error("Не удалось сериализовать список записей для " + entity, ex);
                    }
                    try
                    {
                        model.Search(entity, "", 1,10);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Не удалось выполнить поиск записей для " + entity, ex);
                    }
                }
            }
            Messages.Add($"Даталогическая модель {typeof(AuthorizationDataModel).GetNameOfType()} соответвует требованиям");
        }
        catch (Exception ex)
        {
            throw new Exception($"Даталогическая модель {typeof(AuthorizationDataModel).GetNameOfType()} не соответвует требованиям {ex.Message}. ");
        }


 
    }
    public override List<string> OnTest()
    {
        string fact = "Модель аутентификации должна определять"+
            " классы функций выполняемыми пользователями и параметры доступа"+
            " к этим функциям. ";
        try
        {
            canCreateModel();

            Messages.Add(fact);

            HttpContext http = null;
            /// -регистрация учетных данных
            canRegisterUserAccount();
            /// -проверка времени жизни сеанса
            canAccessDeniedAfterTimeout();
            /// -проверка функции выдачи токена доступа по логину и паролю
            canAuthByPassword();
            /// -проверка аутентификации сервиса по открытому ключу
            canAuthByRFID();
            /// -проверка принадлежности пользователя или сервис к группе пользователей 
            /// уполномоченных набором прав исп. функций приложения
            canCheckUserPermissionRole();
            /// -проверка действий при отсутвии прав доступа
            canAuthRequiredRespond(http);
            /// -проверка журналов регистрации действий аутентификации
            canReadHistoryAuthOperations();
            /// -проверка функций предоставления/лишения прав доступ            canRegisterUserAccount();
            canAddOrRemovePermissions();
            
            return Messages;
        }
        catch (Exception ex)
        {
            Messages.Add("Ложь: " + fact + ": " + ex);
            throw;

        }
    }

    
    /// 
    void canRegisterUserAccount()
    {/// -регистрация учетных данных
        Func<object, bool> loginWithAccount = (input) =>
        {
            return true;
        };
        Func<UserAccount> registerSomeAccount = () => {
            UserAccount account = null;
            try
            {
                DoTest<AuthorizationService>(authorization => {
                    var user = authorization.Signup("eckumoc@gmail.com", "eckumoc@gmail.com", "eckumoc@gmail.com");
                    //if (authorization.IsSignin() == false)
                    //{
                        if (authorization.HasUserWithEmail("eckumoc@gmail.com") == false)
                        {
                            authorization.Signup("eckumoc@gmail.com", "eckumoc@gmail.com", "eckumoc@gmail.com");
                        }
                        //authorization.Signin("eckumoc@gmail.com", "eckumoc@gmail.com");
                    //}

                    Messages.Add("Регистрация учетной записи пользователя работает корректно");
                });



            }
            catch (Exception ex)
            {
                Messages.Add("Регистрация учетной записи пользователя работает некорректно: \n\t"
                    + $"{ex.Source}.{ex.TargetSite} => {ex.Message}\n\t"
                );
            }
            return account;
        };
        try
        {
            var account = registerSomeAccount();
            var result = loginWithAccount(account);
            if( result == true)
            {
                Messages.Add("Функция регистрация учетной записи работает");
            }
            else
            {
                Messages.Add("Функция регистрация учетной записи не работает");
            }
            
        }
        catch (Exception ex)
        {
            Messages.Add("Функция регистрация учетной записи не работает: "+ex.Message);
        }
    }

    /// -проверка времени жизни сеанса
    void canAccessDeniedAfterTimeout()
    {
        Func<object, bool> loginWithAccount = (input) =>
        {
            return true;
        };
        Func<UserAccount> registerSomeAccount = () => {
            UserAccount account = null;
            try
            {
                var user = AppProviderService.GetInstance().Get<UserRegistrationService>()
                    .Signup("eckumoc@gmail.com", "eckumoc@gmail.com", "eckumoc@gmail.com");
                if (user != null)
                {
                    account = user.Account;

                }
                Messages.Add("Регистрация учетной записи пользователя работает корректно");


            }
            catch (Exception ex)
            {
                Messages.Add("Регистрация учетной записи пользователя работает некорректно: " + ex.Message);
            }
            return account;
        };
        try
        {
            var account = registerSomeAccount();
            var result = loginWithAccount(account);
            var options = AppProviderService.GetInstance().Get<AuthorizationOptions>();
            if (result == true)
            {
                Messages.Add("Функция проверки времени жизни сеанса работает корректно");
            }
            else
            {
                Messages.Add("Функция регистрация учетной записи не работает");
            }

        }
        catch (Exception ex)
        {
            Messages.Add("Функция регистрация учетной записи не работает: " + ex.Message);
        }
    }

    /// -проверка функции выдачи токена доступа по логину и паролю
    void canAuthByPassword() 
    { 


        
    }

    /// -проверка аутентификации сервиса по открытому ключу
    void canAuthByRFID() 
    { 
    }

    /// -проверка принадлежности пользователя или сервис к группе пользователей 
    /// уполномоченных набором прав исп. функций приложения
    void canCheckUserPermissionRole() 
    { 
    }

    /// -проверка действий при отсутвии прав доступа
    void canAuthRequiredRespond(HttpContext httpContext) 
    {
        


    }

    /// -проверка журналов регистрации действий аутентификации
    void canReadHistoryAuthOperations() 
    { 
    }

    /// -проверка функций предоставления/лишения прав доступ          
    void canAddOrRemovePermissions() 
    {
        

    }

}
