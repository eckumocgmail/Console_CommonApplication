


using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface APICollection<T>
{
    bool Has(string key);
    T Take(string key);
    T Remove(string key);
    string Put(T item);
    string Find(T item);
    IList<T> GetAll();
    void RemoveAll();
}

public interface APIActiveCollection<T> : DoCheck, APICollection<T> where T : ActiveObject
{

    ConcurrentDictionary<int, object> GetViewSession(string key);
    ConcurrentDictionary<string, object> GetUserSession(string key);
    ConcurrentDictionary<string, T> GetMemory();
}


/// <summary>
/// Коллекция объектов сеанса
/// </summary>
/// <typeparam name="TActiverObject">Тип обьектов сеанса</typeparam>
public abstract class AuthorizationCollection<TActiverObject>: 
    APIActiveCollection<TActiverObject> where TActiverObject : ActiveObject, DoCheck
{
    
    public ConcurrentDictionary<string, ConcurrentDictionary<int, object>> _views { get; set; }
    public ConcurrentDictionary<string, TActiverObject> _memory { get; set; }
    public ConcurrentDictionary<string, ConcurrentDictionary<string, object>> _sessions { get; set; }
    [Service] public AuthorizationOptions _options { get; set; }

    protected AuthorizationCollection( 
                AuthorizationOptions options )
    {
        this._options = options;


        this._memory = new ConcurrentDictionary<string, TActiverObject>();
        this._sessions = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();
        
    }

    public ConcurrentDictionary<string, TActiverObject> GetMemory() => _memory;


    /// <summary>
    /// Добавление обьекта в коллекцию
    /// </summary>
    /// <param name="item"> ссылка на обьект</param>
    /// <returns>ключ доступа к обьекту</returns>
    public virtual string Put(TActiverObject item)
    {
        this.Info($"Добавление ({item})");
        
        lock (this._sessions)
        {
            if (this._memory.Values.Contains(item))
            {
                return this._memory.Where(kv => kv.Value == item).Select(kv => kv.Key).FirstOrDefault();
            }
            else
            {
                string key = this.GenerateKey();
                this._memory[key] = item;
                this._sessions[key] = new ConcurrentDictionary<string, object>();
                item.IsActive = true;
                item.LastActiveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                item.SecretKey = key;
                return key;
            }
            
        }
    }



    public T GetService<T>()
    {        
        return this.GetSingleton<T>();
    }

    /// <summary>
    /// Метод получения контекста сеанса
    /// </summary>
    /// <param name="key">ключ доступа</param>
    /// <returns></returns>
    public ConcurrentDictionary<string,object> GetUserSession(string key)
    {
        if (key == null)
            return null;
        if(_sessions.ContainsKey(key))
        {
            return _sessions[key];
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Получение всех обьектов коллекции 
    /// </summary>
    /// <returns>список обьектов</returns>
    public IList<TActiverObject> GetAll()
    {
        return new List<TActiverObject>(_memory.Values);
    }


    /// <summary>
    /// Метед уничтожения сервиса
    /// </summary>
    public void Dispose()
    {
        this.Info("Уничтожение()");
        this.RemoveAll();
    }


   
        

    /// <summary>
    /// Получение ссылки на обьект по заданному ключу
    /// </summary>
    /// <param name="key">ключ доступа</param>
    /// <returns>ссылка на обьект</returns>
    public TActiverObject Take( string key )
    {
        this.Info($"Извлечение ({key})");
        if ( this._memory.ContainsKey(key))
        {
            TActiverObject target = this._memory[key];
            target.LastActiveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return target;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Извлечение обьекта с заданным ключом из коллекции
    /// </summary>
    /// <param name="key">ключ доступа </param>
    /// <returns>ссылка на объект </returns>
    public TActiverObject Remove(string key)
    {
        this.Info($"Удаление ({key})");
        if (this._memory.ContainsKey(key))
        {
            ConcurrentDictionary<string, object> targetSession = null;
            TActiverObject target = null;
            this._memory.TryRemove(key, out target);
            this._sessions.TryRemove(key, out targetSession);
            foreach(object model in new List<object>(targetSession.Values))
            {
                if(model is IDisposable)
                {
                    IDisposable disposable = (IDisposable)model;
                    disposable.Dispose();
                }
            }
            target.IsActive = false;
            target.SecretKey = "";
            return target;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Извлечение всех обьектов из коллекции
    /// </summary>
    public void RemoveAll()
    {
        foreach (var pair in this._memory)
        {
            this.Remove(pair.Key);
        }
    }


    /// <summary>
    /// Поиск обьекта в коллекции
    /// </summary>
    /// <param name="item">ссылка на обьект</param>
    /// <returns>ключ доступа</returns>
    public string Find(TActiverObject item)
    {
        this.Info($"Поиск ({item})");
        foreach (var pair in this._memory)
        {
            TActiverObject user = pair.Value;
            if (user.Equals(item))
            {
                return pair.Key;
            }
        }
        return null;
    }


    


    /// <summary>
    /// Вычисление уникального ключа в данном контексте
    /// </summary>
    /// <returns> уникальный ключ </returns>
    private string GenerateKey()
    {
        string key = null;
        do
        {
            key = RandomString();
        } while (this._memory.ContainsKey(key));
        return key;
    }


    /// <summary>
    /// Получение случайной последовательности символов
    /// </summary>
    /// <returns> последовательность символов </returns>
    private string RandomString()
    {
        Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() +
                        "0123456789";
        return new string(Enumerable.Repeat(chars, this._options.KeyLength)
                            .Select(s => s[random.Next(s.Length)]).ToArray());
    }


    /// <summary>
    /// Получение текущего времени в милисекундах
    /// </summary>
    /// <returns></returns>
    protected long GetTimestamp()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }


    /// <summary>
    /// Проверка наличия обьекта с заданным ключом
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Has(string key)
    {
        return this._memory.ContainsKey(key);
    }

 

    /// <summary>
    /// Выполнение проверки активности обьектов данной коллекции,
    /// при условии отсутствии активности обьект извлекается
    /// </summary>
    public async Task DoCheck(long timeout)
    {
        var timestamp = this.GetTimestamp();
        this.Info($"[{timeout}]: Кол-во объектов: " + this._memory.Count());
        await Task.CompletedTask;

        GenerateKey();
        
        foreach (var pair in this._memory)
        {
            ActiveObject user = pair.Value;
 
            if ((timestamp - user.LastActiveTime) > _options.SessionTimeout)
            {
                this.Info($"[{timestamp}]: Удаление сеанса: " + pair.Key);
                this.Remove(pair.Key);
            }
        }
        await Task.CompletedTask;
    }

    public ConcurrentDictionary<int, object> GetViewSession(string key)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}

