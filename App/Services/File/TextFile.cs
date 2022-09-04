using System;
using System.Linq;

using static Api.Utils;

/// <summary>
/// Программа обработки текстовых файлов 
/// </summary>
public class TextFile: FileResource<TextDocument>
{

    public static string NUMBERS = "1234567890";

    public TextFile(IServiceProvider provider, string path): base(path)
    {

    }

    //  Во всех других случаях – посчитать количество знаков препинания.  
    public static void OnChange(string ChangeType, string FilePath)
    {
        if(ChangeType == "Created")
        try
        {
            /// <summary>
            /// Сhar.IsPunctuation- 
            ///     Показывает, относится ли указанный символ Юникода к категории знаков препинания.                                                
            /// </summary>
            int countOfChars = System.IO.File.ReadAllText(FilePath).ToCharArray().Where(ch => Char.IsPunctuation(ch)).Count();
            Info("Кол-во знаков пунктуации: " + countOfChars);
            string fileName = $"{ProgramDirectory.ParseFileName(FilePath)}-pchars-count";
            System.IO.File.WriteAllText(fileName, countOfChars.ToString());
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение в результате подсчёта количества знаков пунктуации в файле: " + FilePath, ex);
        }

    }

         
}
