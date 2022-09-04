
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class FilesServiceLocal: Local, IFilesServiceModel 
{ 

    [NotNullNotEmpty()]
    public IHierDictionaryFasade<FileCatalog> FileCatalogsFasade { get; set; }

    [NotNullNotEmpty()]
    public IFilesEntityFasade<TextResource> TextResourcesFasade { get; set; }

    [NotNullNotEmpty()]
    public IFilesEntityFasade<PhotoResource> PhotoResourcesFasade { get; set; }

    [NotNullNotEmpty()]
    public IFilesEntityFasade<AudioResource> AudioResourcesFasade { get; set; }

    [NotNullNotEmpty()]
    public IFilesEntityFasade<VideoResource> VideoResourcesFasade { get; set; }




    private readonly HttpClient _http;
    private readonly string _url;

    public FilesServiceLocal( FilesDataModel dataModel, HttpClient httpClient, string baseUrl ) : base(AppProviderService.GetInstance())
    {
        this._http = httpClient;
        this._url = baseUrl;

        this.PhotoResourcesFasade = new FilesEntityFasade<PhotoResource>(dataModel);
        this.FileCatalogsFasade = new DbHierDictionaryFasade<FileCatalog>(dataModel);
        this.TextResourcesFasade = new FilesEntityFasade<TextResource>(dataModel);
        this.AudioResourcesFasade = new FilesEntityFasade<AudioResource>(dataModel);
        this.VideoResourcesFasade = new FilesEntityFasade<VideoResource>(dataModel);
        this.PhotoResourcesFasade = new FilesEntityFasade<PhotoResource>(dataModel);

        this.EnsureIsValide();
    }

    public Task<int> SaveIntoDb(string name, string path) 
    {
        throw new Exception();
    }
    public Task<int> SaveIntoDirectory(string name, string path)
    {
        throw new Exception();
    }

    /*
    
    /// <summary>
    /// Сохранение каталога в базу данных
    /// </summary>
    /// <param name="name">Имя каталога в базе данных</param>
    /// <param name="path">Путь в локальной файловой системе</param>
    /// <returns></returns>
    public async Task<int> SaveIntoDb( string name, string path )
    {
        this.Info($"Просматриваем каталог '{name}': {path}");

        var catalog = new TypeCatalog(path, name);
        FileCatalog dataset = catalog.ToFileCatalog();
        return await this.FileCatalogsFasade.Create(dataset);        
    }

    public async Task<int> SaveIntoDirectory(string name, string path)
    {
        foreach(var file in this.FileResourcesFasade
            .GetDbSet()
            .Where(file => file.CatalogID == this.FileCatalogsFasade.GetDbSet()
            .Where(catalog => catalog.Name == name)
            .Select(c => c.ID).FirstOrDefault()))
        {
            using (FileStream fs = new System.IO.FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Write(file.Data);
                await fs.FlushAsync();
            }
        }



        return 1;


    }



    /// <summary>
    /// Модель директории в файловой системе.
    /// При инициаллизации считывает все внутрении файлы.
    /// </summary>
    public class TypeCatalog : TypeNode<Dictionary<string, FileEntity>>
    {
        /// <summary>
        /// Конструктор корня иерархии
        /// </summary>
        /// <param name="path"></param>
        /// <param name="rootName"></param>
        public TypeCatalog(string path, string rootName) : base(rootName, new Dictionary<string, FileEntity>(), null)
        {
            ReadFiles(path);
            foreach (string dir in System.IO.Directory.GetDirectories(path))
            {
                string name = dir.Substring(path.Length + 1);
                TypeCatalog subcatalog = new TypeCatalog(dir, name, this);
            }
        }

        /// <summary>
        /// Конструктор дочернего узла
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        private TypeCatalog(string path, string name, TypeCatalog parent) : base(name, new Dictionary<string, FileEntity>(), parent)
        {
            ReadFiles(path);
            foreach (string dir in System.IO.Directory.GetDirectories(path))
            {
                string childName = dir.Substring(path.Length + 1);
                TypeCatalog subcatalog = new TypeCatalog(dir, childName, this);
                Append(subcatalog);
            }
        }



        /// <summary>
        /// Считывание файлов
        /// </summary>
        /// <param name="path">путь к каталогу</param>
        private void ReadFiles(string path)
        {
            foreach (string filepath in System.IO.Directory.GetFiles(path))
            {
                string name = filepath.Substring(path.Length + 1);
                int i = name.LastIndexOf(".");
                string ext = "text/plain";
                if (i != -1)
                {
                    ext = name.Substring(i + 1).ToLower();
                }
                Item[name] = new FileEntity()
                {
                    Name = name,
                    Mime = $"text\\{ext}",
                    Data = System.IO.File.ReadAllBytes(filepath),
                    Changed = System.IO.File.GetLastWriteTime(filepath)
                };
            };
        }



        public FileCatalog ToFileCatalog()
        {
            var result = new FileCatalog();
            result.Name = this.Name;
            foreach (FileEntity FileResource in this.Item.Values)
            {
                result.Files.Add(new FileEntity()
                {
                    Data = FileResource.Data,
                    Changed = FileResource.Changed,
                    Name = FileResource.Name,
                    Description = FileResource.Description,
                    Mime = FileResource.Mime,
                });
            }
            return result;
        }

    }

    public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }*/
}