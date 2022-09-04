using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

using RootLaunch;
using System;

public class FileResource<T> where T : class
{
    public string FilePath { get; set; }
    public FileResource PFileResource { get; set; }


    public T Model { get; set; }
    public bool Initialized = false;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    public FileResource(string filePath)
    {
        if (System.IO.File.Exists(filePath) == false)
            System.IO.File.WriteAllText(filePath, typeof(T).New().ToJson());
        this.FilePath = filePath;
        this.InitFileController();
    }

    /// <summary>
    /// Создаёт файл со значениями по-умолчанию , если он отсутсвует
    /// </summary>
    private void InitFileController()
    {
        lock (this)
        {
            if (Initialized == false)
            {
                string json = null;
                if (System.IO.File.Exists(this.FilePath) == false)
                {
                    this.Model = (T)typeof(T).New();
                    json = Model.ToJson();
                    json.WriteToFile(this.FilePath);
                }
                this.PFileResource = new FileResource(this.FilePath);
                json = this.PFileResource.ReadText();
                Model = json.FromJson<T>();
                this.Initialized = true;

            }
        }
    }


    /// <summary>
    /// Возвращает модель считанную из файла
    /// </summary>
    public T Get()
    {
        lock (this)
        {
            this.InitFileController();

            return Model;
        }
    }


    /// <summary>
    /// Вывод модели в файл
    /// </summary>
    public void Set()
    {
        lock (this)
        {
            this.InitFileController();
            string json = Model.ToJson();
            this.PFileResource.WriteText(json);

            Console.WriteLine($"\n{GetType().GetTypeName()} Записано: \n{json.Length} байт");

        }
    }
}

public class FileResource
{
    public int ID { get; set; }
    private DateTime AccessTime;
    private DateTime WriteTime;

   

    public string Path { get; }
 
    public bool IsDirectory { get => System.IO.Directory.Exists(Path); }
    public bool IsFile { get => System.IO.File.Exists(Path); }
    public string NameShort {
        get => GetNameShort(); 
    }
    public string GetNameShort()
    {
        return this.Path.Substring(ResourceManager.GetParentPath(this.Path).Length + 1);
    }
    public string GetName()
    {
        int i=NameShort.IndexOf(".");
        return i==-1? NameShort: NameShort.Substring(0, i);
    }
    public string GetExt()
    {        
        var shName = NameShort;
        var i = shName.IndexOf(".");

        return shName.Substring(i + 1);        
    }
    
    private byte[] Data { get; set; }
    public bool IsInner { get; }

    public byte[] ReadBytes()
    {
        if (Data == null)
        {
            this.Data = System.IO.File.ReadAllBytes(this.Path);
        }
        return this.Data;
    }

    public FileResource()
    {
    }

    public FileResource( string pathAbs )
    {                        
        this.Path = pathAbs;
        this.ID = this.NameShort.GetHashCode();
 

        if (this.IsDirectory==false && this.IsFile == false)
        {
            this.IsInner = this.Path.StartsWith(System.IO.Directory.GetCurrentDirectory());
            System.IO.File.Create(this.Path);
            if (this.IsDirectory == false && this.IsFile == false )
            {
                throw new Exception($"[404][" + pathAbs + $"] => Путь=[{pathAbs}] не существует такого файла, кстати говоря я проверил директории что такой нету.. .");
            }
        }
        
    }

    public object Modify(string v)
    {
        throw new NotImplementedException();
    }

    public virtual void OnInit()
    {         
        this.AccessTime = System.IO.File.GetLastAccessTimeUtc(this.Path);
        this.WriteTime = System.IO.File.GetLastWriteTime(this.Path);                    
    }


    public byte[] GetBInaryData() => this.Data;



    public virtual bool Copy(string directory)
    {
        var ctrl = DirectoryResource.Get(directory);
        ctrl.CreateFile(NameShort).WriteText(ReadText());
        return true;
    }

    public string ReadText()
    {
        this.Info($"ReadText({this.NameShort})");
        return System.IO.File.ReadAllText(this.Path);
    }
    public void WriteText(string context)
    {
        //this.Info($"WriteText({this.Path})");
        System.IO.File.WriteAllText(this.Path, context);
    }
    public async Task<string> ReadTextAsync()
    {
        return await System.IO.File.ReadAllTextAsync(this.Path);
    }
    public async Task WriteTextAsync(string context)
    {
        await System.IO.File.WriteAllTextAsync(this.Path, context);
    }

    public virtual DirectoryResource[] GetDirectories()
    {
        /*if (IsFile)
        {
            throw new Exception("Не возможно получить список директорий для файла " + this.Path);
        }*/
        try{
            var dirs = System.IO.Directory.GetDirectories(this.Path);
            return dirs.Select(path => DirectoryResource.Get(path)).ToArray();
        }catch(Exception ex){
            this.Error(ex);
            
            throw;
        }
        
    }

    public virtual FileResource[] GetFiles()
    {
        if (IsFile)
        {
            throw new Exception("Не возможно получить список директорий для файла " + this.Path);
        }
        return System.IO.Directory.GetFiles(this.Path).Select(path => new FileResource(path)).ToArray();
    }

    public virtual FileResource[] GetAllFiles()
    {
        var resources = new List<FileResource>();
        if (IsFile)
        {
            throw new Exception("Не возможно получить список директорий для файла " + this.Path);
        }
        resources.AddRange(System.IO.Directory.GetFiles(this.Path).Select(path => new FileResource(path) ).ToArray());
        GetDirectories().ToList().ForEach(dir=> resources.AddRange(dir.GetAllFiles()));
        return resources.ToArray();
    }

    private FileResource GetFiles(string path)
    {
        return new FileResource(ResourceManager.GetChildPath(this.Path, path));
    }

    public virtual FileResource GetParent(   )
    {
        return new FileResource(ResourceManager.GetParentPath(this.Path));
    }

    

    public override string ToString()
    {
        return Path;
    }
 
}
