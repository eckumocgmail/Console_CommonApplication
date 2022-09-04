using ApplicationCore.Converter;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

using ReCaptcha;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using static Api.Utils;

/// <summary>
/// Функции:
    /// 1)Тестирование
    /// 1.а)Модульное тестирование
/// 1.б)Функциональное тестирование
/// 1.в)Интеграционное тестирование
/// 
/// 2)Настройка
/// 2.а)Настройка уведомлений
/// 2.а)Настройка источников данных
/// 2.а)Настройка компонентов представления
/// 2.а)Настройка служб выполняющихся в фоновом режиме
/// 
/// 3)Выполнение
/// 3.а)Выполнение в безопасном режиме
///     Предполагает выполнение операций в процессе отдельном от основного.
/// За счёт этого системные прерывания не повлияют на основной процесс.
/// 
/// </summary>
public class StartCommonApplication
{
    /// <summary>
    /// Выполнение в интерактивном режиме, предполагает 
    /// использование интерфейса взаимодействия с пользователем.
    /// </summary>
    public static bool UserInteractive = Environment.UserInteractive;

    /// <summary>
    /// Исполнение программы начинается с отображения главного меню
    /// </summary>
    private static void Main(params string[] args)
    { 

        ConfigSys();            
        UserInteractive = false;
        string[] steps = new string[] { "1","eckumoc@gmail.com", "sgdf"};
        StartApp(ref steps);
    }

    /// <summary>
    /// Настройка системы исп. статические файлы конфигурации
    /// </summary>
    private static IConfiguration ConfigSys()
    {
        Info("Конфигурация приложения");
        var builder = new ConfigurationBuilder();
        foreach (string file in GetJsonFiles())
        {
            Info(" обнаружен файл конфигурации: "+file);
            builder.AddJsonFile(file);
        }
        return builder.Build();
    }



    /// <summary>
    /// Исполнение программы
    /// </summary>
    private static void StartApp(ref string[] args)
    {           
        Login(ref args);
        MainMenu(ref args);       
    }

    private static UserAccount Login(ref string[] args)
    {
        Clear();
        return Api.Utils.Input<UserAccount>( ref args );
    }

    /// <summary>
    /// Ото в главное меню
    /// </summary>
    public static void MainMenu(ref string[] args)
    {
        Clear();
        switch (ProgramDialog.SingleSelect("Выберите действие", new string[]{
            "Программы","Тестирование","Настройка","Выполнение","Консоль","Выход" }, ref args))
        {
            case "Программы":
                RunProgramsMenu(ref args); break;
            case "Тестирование":
                RunTest(ref args); break;
            case "Настройка":
                RunConfig(ref args); break;
            case "Выполнение":
                RunHost(ref args); break;
            case "Консоль":
                RunConsole(ref args); break;
            case "Выход":
                Process.GetCurrentProcess().Kill();
                break;
            default: break;
        }
    }

    /// <summary>
    /// Директория для хранения учетных данных
    /// </summary>
    private static readonly string AppLoginDir =
        System.IO.Path.Combine(
            System.IO.Directory.GetCurrentDirectory(), "Login").ToString();


    private static void RunHost(ref string[] args)
        => RunCommonApplication.Start(ref args);


    public static void Execute(ref string[] args)
    {
        Clear();
        if (args.Length == 0)
        {
            MainMenu(ref args);
        }
        else
        {
            IHost Localhost = null;
            Info("Просматриваю аргументы выполнения: ");
            foreach (var arg in args)
            {
                bool isClassName = false;


                Info("Аргумент: " + arg);
                foreach (string name in GetClassNames())
                {
                    isClassName = arg.Contains(name);
                    MethodInfo run = name.ToType().GetMethods().FirstOrDefault(m => m.Name.ToLower() == "Run".ToLower());
                    if (isClassName)
                    {
                        string suffix = arg.Substring(arg.IndexOf(name + name.Length));
                        using (var scope = Localhost.Services.CreateScope())
                        {
                            using (var ns = scope.ServiceProvider.GetService<NameServiceProvider>())
                            {
                                var target = ns.GetService(name);
                                var type = name.ToType();
                                if (target is TestingElement)
                                {
                                    Info(((TestingElement)target).DoTest().ToDocument());
                                    break;
                                }
                                else if (run != null)
                                {
                                    StartCommonApplication program = ReadSingleJsonFileOrDefault(new StartCommonApplication());

                                    List<object> argv = GetArgumentsList(arg, name, run, ns, type);
                                    run.Invoke(target, argv.ToArray());
                                }
                                else
                                {
                                    throw new ArgumentException(arg);
                                }
                            }
                        }
                    }

                }
            }
        }
    }


    

    private static void RunProgramsMenu(ref string[] args)
    {
        Clear();
        switch (ProgramDialog.SingleSelect("Выберите действие", new string[]{
            "Назад","Тестирование","Настройка" }, ref args))
        {
            case "Назад":
                MainMenu(ref args); 
                break;
            case "Тестирование":
                RunProgramTestsMenu(ref args); 
                break;
            case "Настройка":
                RunHost(ref args); 
                break;           
            default: break;
        }
    }

    private static void RunProgramTestsMenu(ref string[] args)
        => TestCommonApplication.RunTest(ref args);

    private static List<object> GetArgumentsList(string arg, string serviceTypeName, MethodInfo run, NameServiceProvider ns, Type type)
    {
        var argv = new List<object>();
        foreach (ParameterInfo par in run.GetParameters())
        {
            if (AttrsUtils.IsParameterInjectable(serviceTypeName, run.Name, par.Name))
            {
                try
                {
                    argv.Add(ns.GetService(par.ParameterType));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось собрать аргументы для {type.GetNameOfType()} " +
                        $"выполнения операции {run.Name} на шаге обработки аргумента {arg}. " +
                        $"В пространстве имён отсутсвиет тип {par.ParameterType.GetNameOfType()} либо он не зарегистрированв ServiceProvider", ex); ;
                }
            }
        }

        return argv;
    }

    private static void RunConsole(ref string[] args)
    {
        Clear();
        string command = null;
        do
        {
            command = Api.Utils.InputString(ref args, "Команда");
            try
            {
                if (command == "")
                {

                }
                Api.Utils.Run(command);

            }
            catch (Exception ex)
            {
                Error($"Ошибка при исполнении команды: {command}", ex);
                break;
            }
        } while (true);

        Console.Write(">");
        Console.ReadLine();
    }

    public static void RunTest(ref string[] args) => global::TestCommonApplication.Main(ref args);
    public static void RunConfig(ref string[] args) => global::ConfigureCommonApplication.Start(ref args);


}


