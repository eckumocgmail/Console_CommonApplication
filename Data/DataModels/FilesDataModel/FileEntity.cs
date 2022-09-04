

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;


public class FileEntity: FileEntity<Dictionary<string,object>>
{ 
}

[Label("Файловый ресурс")]
public abstract class FileEntity<EntityType>: DictionaryTable, Convertable<EntityType>
    where EntityType: class
{
    [NotNull]
    [Label("Тип файла")]
    //[SelectControlAttribute("{{GetMimeTypes()}}")]
    [NotNullNotEmpty("Необходимо ввести задать тип ресурса (MimeType)")]
    public string Mime { get; set; }

    [Label("Файл")]
    [InputFile("")]
    public byte[] Data { get; set; }

    [Label("Дата загрузки")]
    [InputDateTime()]
    [NotInput("")]
    [NotNullNotEmpty("Необходимо указать время создания ресурса")]
    public DateTime Created { get; set; } = DateTime.Now;

    [InputDateTime()]
    [NotNullNotEmpty("Необходимо указать время создания ресурса")]
    public DateTime Changed { get; set; }


    public FileEntity(){}
    

 
    [Label("Каталог")]
    public int CatalogID { get; set; }
    public virtual FileCatalog Catalog { get; set; }

    public EntityType Convert()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}
