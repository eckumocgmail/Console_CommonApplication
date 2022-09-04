 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace eckumoc.Utils
{
    public class JsUtils   
    {
        private static string JAVA_SCRIPT_APPLICATION_FILE = "index.js";


        /// <summary>
        /// Выполнение javascript
        /// </summary>
        public string Eval( string code )
        {
            
            return Eval( new string[1] { code } );
        }

        public string Exec(string command)
        {
            ProcessStartInfo info = new ProcessStartInfo("CMD.exe", "/C " + command);

            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
            string response = process.StandardOutput.ReadToEnd();
            return response;
        }

        /// <summary>
        /// Выполнение javascript
        /// </summary>
        public string Eval( string[] lines )
        {
            WriteToFile(lines);            
            return this.Exec("node " + JAVA_SCRIPT_APPLICATION_FILE).TrimEnd();
        }


        /// <summary>
        /// Запись кода в текстовый файл
        /// </summary>
        private void WriteToFile(string[] lines)
        {
            string code = "";
            foreach (string arg in lines)
            {
                code += arg + " \n";
            }
            System.IO.File.WriteAllText(JAVA_SCRIPT_APPLICATION_FILE, code);
        }

        
    }
}
