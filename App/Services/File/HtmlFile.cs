using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Api.Utils;

/// <summary>
/// Программа обработки HTML-формата
/// </summary>
public class HtmlFile: TextFile
{
    public HtmlFile(IServiceProvider provider, string path) : base(provider, path)
    {
    }

    /// <summary>
    /// Обход html-документа
    /// </summary>
    public static void ForEachChildNode(INode Node, Action<INode> ToDo)
    {
        ToDo(Node);
        if(Node.ChildNodes!=null && Node.ChildNodes.Count() > 0)
        {
            foreach(INode Child in Node.ChildNodes)
            {
                ForEachChildNode(Child, ToDo);
            }
        }
    }

    /// Обработка событий файловолй системы  
    // Для html файла посчитать количество тегов div	
    public static void OnChange(string ChangeType, string FilePath)
    {
        if (ChangeType == "Created")                
        try                
        {
            Info($@"[{nameof(HtmlFile)}] ""{ChangeType}"" ""{FilePath}""");

            // нужно разобрать XML по тегам
            var parser = new HtmlParser();

            var html = System.IO.File.ReadAllText(FilePath);
            var document = parser.ParseDocument(html);
                    
            int count = 0;
            ForEachChildNode(document.Body, (pnode) => {                    
                if(pnode is IHtmlElement)
                {
                    var element = (IHtmlElement)pnode;
                    if (element.TagName.ToUpper() == "DIV")
                        count++;
                    switch (element.TagName.ToUpper())
                    {
                        default: break;
                    }
                }
            });
      
            Info($"Количество элементов с тегом DIV: " + count);

            string fileName = $"{ProgramDirectory.ParseFileName(FilePath)}-div-count";
            string absPath = Path.Combine(ProgramDirectory.ParseDirName(FilePath), fileName);
            Info(absPath);

                    
            System.IO.File.WriteAllText(absPath, count.ToString());                    
        }
        catch (Exception ex)
        {
            throw new Exception("Исключение при разборе HTML файла: " + FilePath, ex);
        }
    }
        
}
