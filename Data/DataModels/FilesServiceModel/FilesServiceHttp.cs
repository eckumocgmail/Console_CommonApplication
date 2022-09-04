using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


public class FilesServiceHttp: Http, IModel, IFilesServiceModel
{
    public FilesServiceHttp(HttpClient http, ITokenStorage tokens) : base(new HttpClientController(tokens))
    {
    }

    



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




    public Task<int> SaveIntoDb(string name, string path)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task<int> SaveIntoDirectory(string name, string path)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
     
}

