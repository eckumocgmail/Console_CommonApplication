using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;


/// <summary>
///   Расширения объекта для работы с его свойствами и событиями через анализ 
/// имени.
/// 
///   Префиксы для операций:
///   1) before-выполнение пред обраболтки события
///   HasBeenExecuted- глагол Present Perfect Continious(has/have+3ая форма глагола)
///   
///   2) after-выполнение сразу после обработки указанного события
///   AfterExecuted-глагол записывается в форме Past Simple (окончание -ed, либо вторая форма глагола)
///   
///   3) on- выполнение во время выполнения, отмеченной процедуры
///   OnExecuting-глагол записывается в форме   PresentContinious (окончание -ing)
///   
/// </summary>
public static class ReflectionExtensions
{

    public static IEnumerable<string> GetPropertyNames(this object target)
        => target.GetType().GetProperties().Select(property => property.Name);
    public static IEnumerable<string> GetEventNames(this object target)
        => target.GetType().GetEvents().Select(property => property.Name);
    public static IEnumerable<string> GetMethodNames(this object target)
        => target.GetType().GetMethods().Select(property => property.Name);




    /// <summary>
    /// Выбираем действия начинающиеся на On...
    /// Например:
    /// class AuthModule
    /// {
    ///     public byte[] Login(string account, byte[] publicKey );    
    ///     public void OnLoginSuccess()

    ///     
    /// }
    /// </summary>    
    public static IEnumerable<string> GetActionEvents(this object target)
        => target.GetMethodNames().Select(name => name.SplitWords())
            .Where(ids => ids.Contains("On")).ToList().Select(ids => ((ids.Count() >= 2) ? ids.ToArray()[1] : ""));

}


public interface IAgent
{
    public T Get<T>(string name);
    public void Set<T>(string name, T value);
    public Func<T> Getter<T>(string name);


    /// <summary>
    /// Функция вызова метода с заданными параметрами
    /// </summary>
    /// <typeparam name="T">тип возвращаемый методом действия</typeparam>
    /// <param name="name">наименование метода действия</param>
    /// <returns>квитанция</returns>
    public Func<IDictionary<string, object>, MethodResult<T>> Executer<T>(string name)
        where T : class;

    /// <summary>
    /// Создаёт связанные объекты
    /// </summary>    
    public void Bind(object target);
    public void Unbind(object target);
}


/// <summary>
/// 
/// </summary>
public class Agent : ActiveObjectContext 
{

    public static Agent operator +(Agent a) => a;
    public static Agent operator -(Agent a)
    {
        return new Agent(-a.num, a.den);
    }


    public static Agent operator +(Agent a, Agent b)
        => new Agent(a.num * b.den + b.num * a.den, a.den * b.den);

    public static Agent operator -(Agent a, Agent b)
        => a + (-b);

    public static Agent operator *(Agent a, Agent b)
        => new Agent(a.num * b.num, a.den * b.den);

    public static Agent operator /(Agent a, Agent b)
    {
        if (b.num == 0)
        {
            throw new DivideByZeroException();
        }
        return new Agent();// a.num * b.den, a.den * b.num);
    }

    private int num = 0;
    private int den = 0;
    public Agent() { }
    public Agent(int x) { }
    public Agent(int x, int y) { }

    /// <summary>
    /// Колмпиляция выражения относитьео локлаьной области видимости   
    /// </summary>
    /// <param name="expression">выражение</param>
    public object this[string expression]
    {
        get
        {
            try
            {
                return this.Compile(expression);
            }
            catch (Exception)
            {
                throw new CompileExpressionException(expression);
            }
        }
        set
        {
            throw new Exception();
        }
    }

  
    public Func<T> Getter<T>(string name)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Func<IDictionary<string, object>, MethodResult<T>> Executer<T>(string name) where T : class
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Bind(object target)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Unbind(object target)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}


