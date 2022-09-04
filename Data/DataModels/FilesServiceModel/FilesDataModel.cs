 

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

  
public sealed class FilesDataModel: BaseDbContext, IFilesDataModel  
{

    public DbSet<FileCatalog> FileCatalogs { get; set; }
    public DbSet<TextResource> TextResources { get; set; }
    public DbSet<PhotoResource> PhotoResources { get; set; }
    public DbSet<AudioResource> AudioResources { get; set; }
    public DbSet<VideoResource> VideoResources { get; set; }


    public FilesDataModel()
    {
             
    }

    public FilesDataModel(DbContextOptions<FilesDataModel> options): base(options)
    {
    }
    protected override void InitDbSets()
    {
    }
}
 