
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


/// <summary>
/// Модель файлового каталога
/// </summary>
[Label("Файловый каталог")]    
public class FileCatalog : HierDictionary<FileCatalog>
{

    

    public virtual List<FileEntity> Files { get; set; }


    public FileCatalog()
    {
        Files = new List<FileEntity>();
    }

    public FileCatalog(string name)
    {
        Files = new List<FileEntity>();
        Name = name;
    }
    public void ForEach<T>(Action<HierDictionary<FileCatalog>> todo) where T: HierDictionary<FileCatalog>
    {
        this.GetChildren().ForEach((catalog) => { 
            todo(catalog);
        });
    }
}
