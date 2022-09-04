using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Модуль SPA-приложения
/// </summary>    
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class SPAModuleOptions
{
    /// <summary>
    /// Директория дорлжна содержать файл angular.json
    /// </summary>
    public string SourceFilesPath { get; set; } = 
        @"D:\ProjectsEnterpricce\UIComponents\eckumoc-angular-forms";
    public string StaticFilesPath { get; set; } = 
        @"D:\ProjectsEnterpricce\UIComponents\eckumoc-angular-forms\dist";

    public void EnsureIsCorrect()
    {
        if (System.IO.Directory.Exists(SourceFilesPath) == false)
            throw new Exception($"Свойства модуля SPA содержат ошибочные данные. Проверьте путь к исходным файлам SPA приложения. ");
        if (System.IO.Directory.Exists(StaticFilesPath) == false)
            throw new Exception($"Свойства модуля SPA содержат ошибочные данные. Проверьте путь к статическим файлам SPA приложения. ");
    }
}
 
