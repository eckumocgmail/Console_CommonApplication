
using System.Threading.Tasks;

public interface IFilesServiceModel
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

    public Task<int> SaveIntoDb(string name, string path);
    public Task<int> SaveIntoDirectory(string name, string path);
    


}
