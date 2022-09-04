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
/// �������:
    /// 1)������������
    /// 1.�)��������� ������������
/// 1.�)�������������� ������������
/// 1.�)�������������� ������������
/// 
/// 2)���������
/// 2.�)��������� �����������
/// 2.�)��������� ���������� ������
/// 2.�)��������� ����������� �������������
/// 2.�)��������� ����� ������������� � ������� ������
/// 
/// 3)����������
/// 3.�)���������� � ���������� ������
///     ������������ ���������� �������� � �������� ��������� �� ���������.
/// �� ���� ����� ��������� ���������� �� �������� �� �������� �������.
/// 
/// </summary>
public class StartCommonApplication
{
    /// <summary>
    /// ���������� � ������������� ������, ������������ 
    /// ������������� ���������� �������������� � �������������.
    /// </summary>
    public static bool UserInteractive = Environment.UserInteractive;

    /// <summary>
    /// ���������� ��������� ���������� � ����������� �������� ����
    /// </summary>
    private static void Main(params string[] args)
    { 

        ConfigSys();            
        UserInteractive = false;
        string[] steps = new string[] { "1","eckumoc@gmail.com", "sgdf"};
        StartApp(ref steps);
    }

    /// <summary>
    /// ��������� ������� ���. ����������� ����� ������������
    /// </summary>
    private static IConfiguration ConfigSys()
    {
        Info("������������ ����������");
        var builder = new ConfigurationBuilder();
        foreach (string file in GetJsonFiles())
        {
            Info(" ��������� ���� ������������: "+file);
            builder.AddJsonFile(file);
        }
        return builder.Build();
    }



    /// <summary>
    /// ���������� ���������
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
    /// ��� � ������� ����
    /// </summary>
    public static void MainMenu(ref string[] args)
    {
        Clear();
        switch (ProgramDialog.SingleSelect("�������� ��������", new string[]{
            "���������","������������","���������","����������","�������","�����" }, ref args))
        {
            case "���������":
                RunProgramsMenu(ref args); break;
            case "������������":
                RunTest(ref args); break;
            case "���������":
                RunConfig(ref args); break;
            case "����������":
                RunHost(ref args); break;
            case "�������":
                RunConsole(ref args); break;
            case "�����":
                Process.GetCurrentProcess().Kill();
                break;
            default: break;
        }
    }

    /// <summary>
    /// ���������� ��� �������� ������� ������
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
            Info("������������ ��������� ����������: ");
            foreach (var arg in args)
            {
                bool isClassName = false;


                Info("��������: " + arg);
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
        switch (ProgramDialog.SingleSelect("�������� ��������", new string[]{
            "�����","������������","���������" }, ref args))
        {
            case "�����":
                MainMenu(ref args); 
                break;
            case "������������":
                RunProgramTestsMenu(ref args); 
                break;
            case "���������":
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
                    throw new Exception($"�� ������� ������� ��������� ��� {type.GetNameOfType()} " +
                        $"���������� �������� {run.Name} �� ���� ��������� ��������� {arg}. " +
                        $"� ������������ ��� ���������� ��� {par.ParameterType.GetNameOfType()} ���� �� �� ���������������� ServiceProvider", ex); ;
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
            command = Api.Utils.InputString(ref args, "�������");
            try
            {
                if (command == "")
                {

                }
                Api.Utils.Run(command);

            }
            catch (Exception ex)
            {
                Error($"������ ��� ���������� �������: {command}", ex);
                break;
            }
        } while (true);

        Console.Write(">");
        Console.ReadLine();
    }

    public static void RunTest(ref string[] args) => global::TestCommonApplication.Main(ref args);
    public static void RunConfig(ref string[] args) => global::ConfigureCommonApplication.Start(ref args);


}


