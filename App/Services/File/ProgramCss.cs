using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    using static Api.Utils;

    // Для css  файла проверить, что количество
    // открывающих скобок “{“ совпадает с количеством
    // закрывающих скобок “}”	
    public class ProgramCss: ProgramLogger
    {
        /// Обработка событий файловолй системы        
        public static void OnChange(string ChangeType, string FilePath)
        {
            if (ChangeType == "Created")
            try
            {
                Info($@"[{nameof(HtmlFile)}] ""{ChangeType}"" ""{FilePath}""");
                var characters = System.IO.File.ReadAllText(FilePath);

                //символ {- увеличивает level на ед.
                //символ }- увеличивает level на ед.
                int level = 0;

                // анализ
                foreach (var ch in characters)
                {
                    switch (ch)
                    {
                        case '{': level++; break;
                        case '}': level--; break;
                    }
                }

                // результат
                bool result = false;
                if (level == 0)
                {
                    Info("Проверка выполнена");
                    result = true;
                }
                else
                {
                    Info("Синтаксичяеская ошибка");
                    result = false;
                }

                string fileName = $"{ProgramDirectory.ParseFileName(FilePath)}-css-validation";
                string absPath = Path.Combine(ProgramDirectory.ParseDirName(FilePath), fileName);
                Info(absPath);

                System.IO.File.WriteAllText(absPath, result.ToString());              
            }
            catch (Exception ex)
            {
                throw new Exception("Проверка того, что количество открывающих скобок “{“ совпадает с количеством закрывающих скобок “}” в файле " + FilePath, ex);
            }
        }
        
    }
}
