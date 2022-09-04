 

 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
 
/// <summary>
/// Служба управления ресурсами
/// </summary>
public class UserResourcesService
{
    protected AuthorizationDataModel _context;


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="context"></param>
    public UserResourcesService(
        AuthorizationDataModel context,
        IAnaliticsServiceModel analitics,
        IFilesServiceModel files)
    {
        _context = context;
    }

    /// <summary>
    /// Вывод сообщения в консоль
    /// </summary>
    /// <param name="message"></param>
    protected  void Info(object item) {
        string message = $"[{GetType().Name}][{DateTime.Now}] => {item}";
        Debug.WriteLine(message);
        Console.WriteLine(message);
    }



    /// <summary>
    /// Выполняет сохранение каталога в базу данных
    /// </summary>
    /// <param name="fileCatalog"></param>
    public void Save(   )
    {
        try
        {


            FileCatalog fileCatalog = GetFileCatalog("d:\\System-Config","Root");
            Dictionary<string, FileCatalog> catalogs = new Dictionary<string, FileCatalog>();
          /*  fileCatalog.ForEach<FileCatalog>((FileCatalog p) => {
                //_context.
                FileCatalog catalog =
                    catalogs[p.GetPath("\\")] = 
                        new FileCatalog(p.Name); 
                if(p.Parent != null)
                {
                    catalog.Parent = catalogs[p.Parent.GetPath("\\")];
                }
                foreach(TypeFile file in p.Item.Values)
                {
                    FileResource resource = new FileResource(file);
                    catalog.Files.Add(resource);
                    _context.FileResources.Add(resource);
                }
                _context.FileCatalogs.Add(catalogs[p.GetPath("\\")]);
            });*/
            _context.SaveChanges();
        }
        catch(Exception ex)
        {
            Info(ex);
        }
    }

    private FileCatalog GetFileCatalog(string v1, string v2)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
} 