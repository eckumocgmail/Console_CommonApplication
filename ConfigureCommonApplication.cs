using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static Api.Utils;

/// <summary>
/// Класс отвечает за конфигурацию приложения
/// </summary>
[Label("Конфигурация приложения")]
public class ConfigureCommonApplication
{
    [Label("Путь к файйлу с конфигурацией приложения")]    
    public string Path { get; } 

         = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "app.json").ToString().ReplaceAll("\\\\", "\\");

    [Label("Модули уровня данных")]
    public List<string> Data { get; set; } = new List<string>();

    [Label("Модули уровня представления")]
    public List<string> View { get; set; } = new List<string>();

    [Label("Директории динамических ресурсов")]
    public List<string> Dirs { get; set; } = new List<string>();

    [Label("Модули фонового воспроизведения")]
    public List<string> Background { get; set; } = new List<string>();

    [Label("Этапы обработки запросов")]
    public List<string> Pipeline { get; set; } = new List<string>();

    [Label("Адреса веб приложения")]
    [InputStructureCollection()]
    public List<string> Urls { get; set; } = new List<string>();
   

    public ConfigureCommonApplication()
    {
    }


    public IEnumerable<string> GetArguments()
    {
        var result = new List<string>();
        result.AddRange(Data);
        result.AddRange(View);        
      
        result.AddRange(Background);
        result.AddRange(Dirs);
        return result;
    }

    public void Save()
    {
        this.Path.WriteText(this.ToJsonOnScreen());
    }

    public void Load()
    {
            
        if (this.Path.FileExists() == false)
        {
            this.Path.WriteText(this.ToJsonOnScreen());
        }
        else
        {
            try
            {
                string json = this.Path.ReadText();                 
                var data = json.FromJson<ConfigureCommonApplication>();
                this.CopyData( data );
            }
            catch (Exception ex)
            {
                this.Error("Ошибка при считывании JSON",ex);
            }           
        }
        
    }

    

    /// <summary>
    /// Переход в меню конфигурации
    /// </summary>
    public static void Start(ref string[] args)
    {
        Clear();
        var config = new ConfigureCommonApplication();
        config.Load();
        config.Log();
        switch (ProgramDialog.SingleSelect(
            "Выберите действие", new string[]{
                "Назад",
                "Настроить контейнер внедрения зависимостей",
                "Настроить фоновые службы",
                "Настроить внешние библиотеки приложения",
                "Настроить слой данных",
                "Настроить слой представления"
        }, ref args)){
            case "Назад":
                global::StartCommonApplication.MainMenu( ref args);
                break;
            case "Настроить контейнер внедрения зависимостей":
                RunContainerConfig(ref args);
                break;
            case "Настроить конвеер обработки запросов":
                RunHttpPipelineConfig(ref args);
                break;
            case "Настроить внешние библиотеки приложения":
                RunConfigLibs(ref args);
                break;
            case "Настроить фоновые службы":
                RunBackgroundConfig(ref args);
                break;
            case "Настроить слой данных":
                RunDataConfig(ref args);
                break;
            case "Настроить слой представления":
                RunViewConfig(ref args);
                break;
            default: break;
        }
        global::StartCommonApplication.MainMenu(ref args);
    }

    private static void RunConfigLibs(ref string[] args)
    {
        
        ConsoleProgram.RunInteractive(new CollectionBuilder<string>(() => {
            return null;
        },(item) => item ));

    }

    private static void RunContainerConfig(ref string[] args)
    {
        throw new NotImplementedException($"{typeof(ConfigureCommonApplication).GetTypeName()}");
    }

    private static void RunHttpPipelineConfig(ref string[] args)
    {
        throw new NotImplementedException($"{typeof(ConfigureCommonApplication).GetTypeName()}");
    }

    private static void RunBackgroundConfig(ref string[] args)
    {
        Clear();
        var config = new ConfigureCommonApplication();
        config.Load();

        var typeNames = System.Reflection.Assembly.GetExecutingAssembly().GetHostedServices().Select(t => t.GetNameOfType()).ToList<string>();
        var selected = Api.Utils.CheckListTitle<string>(
            "Выберите фоновые службы: ",
            typeNames,
            (name) => name.ToString());
        config.Background.Clear();
        config.Background.AddRange(selected);
        config.Save();

        Start(ref args);
    }


    /// <summary>
    /// Выбор моделей данных
    /// </summary>
    public static void RunDataConfig(ref string[] args)
    {
        Clear();
        var config = new ConfigureCommonApplication();
        config.Load();
        Info(config.ToJsonOnScreen());

        var typeNames = System.Reflection.Assembly.GetExecutingAssembly().GetDataModels().Select(t => t.GetNameOfType()).ToList<string>();
        var selected = Api.Utils.CheckListTitle<string>("Выберите модели данных: ",
            typeNames, config.Data, 
            (name) => name.ToString());
        config.Data.Clear();
        config.Data.AddRange(selected);
        config.Save();
         
        Start(ref args);
    }


    /// <summary>
    /// Выбор моделей представления
    /// </summary>
    public static void RunViewConfig(ref string[] args)
    {
        Clear();

        var typeNames = System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes().Where(t => t.IsExtends(typeof(ViewComponent)))
            .Select(t =>  t.GetNameOfType()).ToList<string>();
        Api.Utils.CheckListTitle<string>("Выберите компоненты представлений: ",
            typeNames,
            (name) => name.ToString()).ToJsonOnScreen().WriteToConsole();
        Api.Utils.ConfirmContinue();
        Start(ref (args));
    }
}