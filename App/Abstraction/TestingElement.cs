using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Api.Utils;

/// <summary>
/// Модуль тестирования наследует данный класс.
/// </summary>
[Icon("")]
[Label("Моддуль тестирования")]
[Description("Объединяет несколько элементов тестирования.")]
public abstract class TestingUnit : TestingElement
{
    protected TestingUnit(TestingUnit parent = null) : base(parent) { }
    public override List<string> OnTest() => Messages;

}


/// <summary>
/// Отчет о тестировании
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class TestReport
{
    [InputText]
    [NotNullNotEmpty]
    public string Name { get; set; }

    [InputBool]
    public bool Failed { get; set; }

    [NotNullNotEmpty]
    public DateTime Started { get; set; }

    [NotNullNotEmpty]
    public DateTime Ended { get; set; }

    [InputStructureCollection(nameof(String))]
    public List<string> Messages { get; set; }

    [InputStructureCollection(nameof(KeyValuePair<string, TestReport>))]
    public Dictionary<string, TestReport> Subreports { get; set; }


    public TestReport(string Name) : this()
    {
        this.Name = Name;
    }

    public TestReport()
    {
        this.Subreports = new Dictionary<string, TestReport>();
        this.Messages = new List<string>();
        this.Failed = false;
    }


    /// <summary>
    /// Фактический номер версии, показывает отношение коль-ва тестов к выполненым
    /// </summary>
    /// <returns></returns>
    public int GetVersion()
        => (from r in this.Subreports.Values where r.Failed == false select r).Count();


    /// <summary>
    /// Фактический номер версии, показывает отношение коль-ва тестов к выполненым
    /// </summary>
    /// <returns></returns>
    public Version GetRealisticVersion()
    {
        if (this.Subreports.Count == 0)
        {
            return new Version(1, this.Failed ? 0 : 1);
        }
        return new Version(
            (from r in this.Subreports.Values where r.Failed == false select r).Count(),
            this.Subreports.Count);
    }

    /// <summary>
    /// Количественный номер версии, показывает кол-во выполненых проверок
    /// </summary>
    /// <returns></returns>
    public Version GetMaximalisticVersion()
    {
        if (this.Subreports.Count == 0)
        {
            return new Version(1, this.Failed ? 0 : 1);
        }
        return new Version((from r in this.Subreports.Values where r.Failed == false select r).Count(), this.Subreports.Count);
    }


    /// <summary>
    /// Версия приложения
    /// </summary>
    public class Version
    {
        int _count;
        int _completed;
        public Version(int completed, int count)
        {
            _count = count;
            _completed = completed;
        }
        public override string ToString()
        {
            return $"{_completed}/{_count}";
        }
    }



    /// <summary>
    /// Метод получчения числовой информации о результатх тестирования 
    /// </summary>
    /// <returns> числовая информация о результатах тестирования </returns>
    public string GetStat()
    {
        if (this.Subreports.Count() == 0)
        {
            return this.Failed ? "0" : "1";
        }
        else
        {
            int inc = 0;
            foreach (var p in this.Subreports)
            {
                if (p.Value.Failed)
                {
                    break;
                }
                else
                {
                    inc++;
                }
            }
            return $"{this.Subreports.Count}-{inc}";
        }
    }


    /// <summary>
    /// Составление текстового документа, содержащего информацию о результатах тестирования
    /// </summary>
    /// <param name="isTopReport"> true, если отчет составлен на верхнем уровне </param>
    /// <returns> теккстовый документ </returns>
    public string ToDocument(string prefix = "1", int level = 0)
    {
        string Document = level == 0 ? "\n\n" : "";
        foreach (string message in Messages)
        {
            for (int i = 0; i < level; i++)
            {
                Document += "    ";
            }
            Document += message + "\n";

        }

        this.Info(Document + "\n");

        string Version = null;
        int Number = 1;
        foreach (var pair in this.Subreports)
        {
            for (int i = 0; i < level; i++)
            {
                Document += "    ";
            }

            Version = $"{prefix} {Number}/{this.Subreports.Count()}";
            Document += $"{Version}: " + pair.Key + "\n";

            this.WriteYellowLine($"{Version}: " + pair.Key + "\n");

            if (String.IsNullOrWhiteSpace(pair.Key.ToType().Label()) == false)
                Document += $"{Version}: " + pair.Key.ToType().Label() + "\n";
            if (String.IsNullOrWhiteSpace(pair.Key.ToType().Description()) == false)
                Document += $"{Version}: " + pair.Key.ToType().Description() + "\n";


            Document += pair.Value.ToDocument(Version, level + 1) + " \n";

            Number++;
        }


        string DirName = "TestReports";
        string DirPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), DirName).ToString();
        if (System.IO.Directory.Exists(DirPath) == false)
        {
            System.IO.Directory.CreateDirectory(DirPath);
        }
        string FileName = GetType().GetTypeName() + ".txt";
        string FilePath = System.IO.Path.Combine(DirPath, DirName);
        System.IO.File.WriteAllText(FilePath, Document);
        Console.WriteLine($"Результат сохранён в {FilePath}");

        return Document;
    }


    /// <summary>
    /// Преобразование в текстовый формат
    /// </summary>
    /// <returns> текстовые данные </returns>
    public override string ToString()
    {
        return JObject.FromObject(this).ToString();
    }
}
/*
/// <summary>
/// Модуль тестирования наследует данный класс.
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public abstract class TestingElement 
{
    protected Dictionary<string, TestingElement> Children = new Dictionary<string, TestingElement>();
    public void LogContents()
    {
        int n = 0;
        for (int i = 0; i < GetLevel(); i++)
            Console.Write(" ");
        Console.WriteLine(@$"[{GetType().GetTypeName()}]: {this.GetType().Label()}");
        foreach (var kv in this.Children)
            kv.Value.LogContents();
    }
    public int GetLevel()
    {
        int level = 0;
        var p = this;
        while (p != null)
        {
            level++;
            p = p.Capter;
        }
        return level;
    }

    /// <summary>
    /// Реализация метода тестирования
    /// public override System.Collections.Generic.List<string> OnTest()
    /// </summary>
    public abstract System.Collections.Generic.List<string> OnTest();


    /// <summary>
    /// Отчёт о проведении тестирования
    /// </summary>
    public TestingElement Capter;
    public List<string> Messages;
    protected TestReport Report;
    protected bool LastResult;

    protected TestingElement(TestingElement parent) :this(){
        Capter = parent;
    }

    protected TestingElement()
    {
        
        Report = new TestReport(this.GetType().GetNameOfType());
        Messages = Report.Messages;
    }

    public string GetSuccessMessage<T>() =>
        $"Тестирование {this.GetTypeName()} класса {typeof(T).GetTypeName()} успешно завершено. ";

    public string GetFailedMessage() =>
        $"Исключение проброшено в ходе выполнения теста {this.GetTypeName()}. ";


    /// <summary>
    /// Выполнение метода тестирования исп. контекст внедрения зависимостей
    /// и регистрация результатов.
    /// </summary>
    public virtual List<string> DoTest<T>(Action<T> todo) where T: class
    {
        try
        {
            var service = this.Get<T>();
            todo(service);    

            this.Messages.Add(this.GetSuccessMessage<T>());

        }
        catch (System.Exception ex)
        {
            string message = GetFailedMessage();
            this.Error(message);
            this.Messages.Add(message);
            throw new System.Exception(message, ex);
        }
        return Messages;
    }

    /// <summary>
    /// Выполнение функции тестирования исп. контекст внедрения зависимостей
    /// и регистрация результатов.
    /// </summary>
    public MethodResult<object> DoTest<T, TResult>(Func<T, TResult> check) where T : class
    {
        var service = this.Get<T>();
        try
        {
            var result = check(service);
            return MethodResult<object>.OnResult(result);
        }
        catch (System.Exception ex)
        {
            return MethodResult<object>.OnError(ex);
        }
    }

    /// <summary>
    /// Приведение к иерархической структуре
    /// </summary>    
    public TypeNode<TestingElement> ToNode()
    {
        var result = new TypeNode<TestingElement>(this.GetTypeName(), this, null);
        foreach (TestingElement child in this.Children.Values)
        {
            var pchildNode = child.ToNode(); 
            pchildNode.Parent = result;
        }
        return result;
    }



    /// <summary>
    /// Внедрение зависимости
    /// </summary>
    public T Get<T>() where T: class
    {
        try
        {
            return AppProviderService
                .GetInstance()
                .Get<T>();
        }catch (System.Exception ex)
        {
            throw new System.Exception(
                $"Исключение при получении зависимости {typeof(T).GetTypeName()}", ex);
        }
    }
        

    
        


    /// <summary>
    /// Добавление метода тестирования
    /// </summary>
    /// <param name="unit"> метод тестирования </param>
    protected  void Push(TestingElement unit)    
        => this.Children[unit.GetType().Name] = unit;
    


    /// <summary>
    /// Выполнения теста и составления отчета о тестировании
    /// </summary>
    /// <returns> отчет о тестировании </returns> 
    public virtual TestReport DoTest(bool strict = false, bool interactive = false)
    {
        

        try
        {
            Clear();

            this.Info($"> { this.GetType().Name }");
            this.Info($"{ this.GetType().Label() }");
            this.Info($"{ this.GetType().Description() }");
             
            if (this.Is<TestingUnit>())
            {
                this.Casts<TestingUnit>().LogContents();
        
                
            }
            else
            {
                this.Info($"> { this.GetType().Name }");
            }

            if (Report==null)
                this.Report = new TestReport(this.GetType().Name);

            Report.Started = DateTime.Now;
            Report.Failed = false;

            if (this.OnTest().Count == 0 && this is TestingUnit == false)
                throw new Exception("Результат тестирования не содержит утверждений. ");
          
            if (this.Is<TestingUnit>()==false)
            {
                if (Report.Failed)
                    this.WriteGreenLine(GetFailedMessage());
                else this.WriteGreenLine(GetSuccessMessage<string>());

                this.Info(this.GetTypeName()+" выполнен");
                Report.ToDocument();
            }
            this.LastResult = true;
        }
        catch (Exception ex)
        {
            this.Error(ex, $"Исключение при выполнении теста {GetType().GetTypeName()}: "+ ex.Message);
            Report.Failed = true;
            Report.Messages.Add( ex.Message );
            ex.StackTrace.WriteToConsole();
            this.LastResult = false;
            if(strict)
                throw new Exception($"Отрицательный результат тестирования "+GetType().GetTypeName
                ()+". ",ex);
        }
        finally
        {                       
            if(this.GetType().IsExtendsFrom(typeof(TestingUnit)) == false)
            {
                if (Report.Messages.Count == 0 && this is TestingUnit == false)
                    throw new Exception(this.GetType().GetNameOfType()+
                        " Тест выполнен некорректно так как отчёт не содержит ни одного утверждения.");                
                if (interactive)
                {
                    Clear();
                    this.Info(this.Report.ToDocument());
                    if (ConfirmDialog("\nТест правильно выполнен тест?") == false)
                        throw new Exception(this.GetType().GetNameOfType() + " не выполнен");
                }
                    
            }
            Report.Ended = DateTime.Now;
            foreach (var p in Children)
            {
                Report.Subreports[p.Key] = p.Value.DoTest(strict, interactive);
                if(Report.Subreports[p.Key].Failed)
                {
                    Report.Failed = true;
                }
            }                    
        }
        return Report;
    }

    private bool ConfirmDialog(string messages)
    {

        Console.WriteLine(messages);
        Console.WriteLine("Введите y/n");
        return (Console.ReadLine() == "y"); 
    }

  
}
*/