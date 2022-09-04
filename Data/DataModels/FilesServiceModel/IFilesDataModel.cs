using Microsoft.EntityFrameworkCore;

public interface IFilesDataModel    
{
    DbSet<FileCatalog> FileCatalogs { get; set; }
    DbSet<TextResource> TextResources { get; set; }
    DbSet<AudioResource> AudioResources { get; set; }
    DbSet<PhotoResource> PhotoResources { get; set; }
    DbSet<VideoResource> VideoResources { get; set; }
}
