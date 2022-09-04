using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using static Api.Utils;

 

namespace Api
{
    using static System.Console;
    using static System.Diagnostics.Activity;
    using static System.Diagnostics.Process;
    using static Microsoft.AspNetCore.Hosting.WebHostBuilder;
    using static System.Threading.Thread;
    using static System.Threading.Tasks.Task;
    using static System.Text.Json.JsonSerializer;
    using static System.Reflection.Assembly;
    using static System.IO.Directory;
    using static System.IO.Path;
    using static Microsoft.Extensions.Hosting.Host;
    using static Microsoft.Extensions.Hosting.HostBuilder;
    using static Microsoft.Extensions.WebEncoders.Testing.HtmlTestEncoder;
    using static System.IO.Compression.ZipFile;
    using static Newtonsoft.Json.JsonConvert;
    using static System.Convert;


    public class Utils : InputApplicationProgram
    {
        
        public void GetDocs(Assembly assembly)
        {
            foreach (var type in assembly.GetClassTypes())
            {
                if (type.Name.StartsWith("<") == false)
                {
                    foreach (char ch in type.GetNameOfType())
                    {
                        if ((ch + "").IsEng() == true || "<,>".Contains(ch))
                        {
                            assembly.Info(type.GetNameOfType());
                        }
                    }
                }


            }
        }
        
        public static IEnumerable<Type> GetDeps(Type type)
        {
            var set = new HashSet<Type>();

            foreach (var constr in type.GetConstructors())
            {
                var pset = constr.GetParameters().Select(p => p.ParameterType).ToHashSet();
                set.AddRange<Type>(pset);
                foreach (var ptype in pset)
                {
                    set.AddRange<Type>(GetDeps(type));
                }
            }
            return set;
        }
        public static IDictionary<string, int> RunStepByStep(Func<string, int> execute, params string[] commands)
        {
            var result = new Dictionary<string, int>();
            foreach (var command in commands)
            {
                try
                {
                    execute(command);
                    result[command] = 1;
                }
                catch (Exception)
                {
                    result[command] = -1;
                }
            }
            return result;
        }

        
        public static T Input<T>( ref string[] args, T item = null) where T : class
        {
            if (item == null)
                item = (T)typeof(T).New();
            var form = new Form(item);
            Clear();
            WriteLine(form.Title);
            ConfirmContinue(ref args,"Необходимо ввести данные");
            List<string> errors = new List<string>();
            Dictionary<string, object> values = new Dictionary<string, object>();
            do
            {
                foreach (var field in form.FormFields)
                {
                    do
                    {
                        Clear();
                        WriteYellow(form.Title);
                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (var kv in values)
                            WriteLine($"\t{kv.Key}: {kv.Value}");
                        errors.ForEach(er => WriteYellow(er));
                        object inputed = null;
                        switch (((FormField)field).Type)
                        {
                            case "Number":
                                {
                                    inputed = InputString(ref args, ((FormField)field).Label);
                                    break;
                                }
                            case "Email":
                                inputed = InputEmail(ref args, ((FormField)field).Label);
                                break;
                            case "Url":
                                inputed = InputUrl(ref args,((FormField)field).Label);
                                break;
                            case "String":
                                inputed = InputString(ref args, ((FormField)field).Label);
                                break;
                            default:
                                inputed = InputString(ref args, ((FormField)field).Label);
                                break;
                        }
                        values[((FormField)field).Label] = inputed;
                        form.Item.SetProperty(((FormField)field).Name, inputed);
                        errors = form.ValidateFormField(((FormField)field));
                    } while (errors.Count > 0);
                    continue;
                }
            } while (ConfirmContinue(ref args, "Подтвердите достоверность данных?") != true);

            
            return (T)form.Item;
        }
        
        
        

        public static T GetService<T>() => AppProviderService.GetInstance().GetService<T>();
        public static long WriteJsonFile<T>(string name, T def)
        {
            System.IO.File.WriteAllText(name, def.ToJsonOnScreen());
            var info = new FileInfo(name);
            return info.Length;
        }
        public static T ReadJsonFile<T>(string name)
        {
            if (FileExists(name) == false)
            {
                throw new IOException("Файл " + name + " не существует");
            }
            else
            {
                try
                {
                    return System.IO.File.ReadAllText(name).FromJson<T>();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Не удалось прочитать файл: " + name, ex);
                }
            }

        }
        public static T ReadSingleJsonFileOrDefault<T>(T def)
        {
            return ReadJsonFileOrDefault<T>(typeof(T).GetNameOfType().ReplaceAll("<", "-").ReplaceAll(">", "_"), def);
        }
        public static T ReadJsonFileOrDefault<T>(string name, T def)
        {
            if (FileExists(name) == false)
            {
                long size = WriteJsonFile<T>(name, def);
                return def;
            }
            else
            {
                return ReadJsonFile<T>(name);
            }
        }
        public static bool FileExists(string name) => System.IO.File.Exists(name);
        public static bool DirectoryExists(string name) => System.IO.Directory.Exists(name);
        public static void Run<T>(Func<T> todo) => Task.Run<T>(todo);
        public static string Serialize(object p) => JsonSerializer.Serialize(p);
        public static T Deserialize<T>(string p) => JsonSerializer.Deserialize<T>(p);
        public static Assembly GetExecutingAssembly() => Assembly.GetExecutingAssembly();
        public static IEnumerable<Type> GetAssemblyTypes() => GetExecutingAssembly().GetClassTypes();
        public static IEnumerable<string> GetClassNamesFull() => GetExecutingAssembly().GetClassTypes().Select(c => c.FullName);
        public static IEnumerable<string> GetClassNames() => GetExecutingAssembly().GetClassTypes().Select(c => c.GetNameOfType());
        public static IEnumerable<string> GetNameSpaces() => GetExecutingAssembly().GetClassTypes().Select(c => c.Namespace);
        public static Assembly Load(byte[] dll) => Assembly.Load(dll);
        public static Assembly LoadFile(string file) => Assembly.LoadFile(file);
        public static Assembly GetEntryAssembly() => Assembly.GetEntryAssembly();
        public static Assembly GetCallingAssembly() => Assembly.GetCallingAssembly();

    }
}

