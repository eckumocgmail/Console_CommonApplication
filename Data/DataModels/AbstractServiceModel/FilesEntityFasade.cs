using System;

public class FilesEntityFasade<T> : EntityFasade<T>, IFilesEntityFasade<T>, IEntityFasade<T>
    where T : FileEntity
{
    public FilesEntityFasade(IDbContext context) : base(context)
    {
    }

    public void Save(int id, string file)
    {
    }


    public void Load(string file)
    {
    }

    public void Listen( string file, Action<System.IO.FileSystemEventArgs> onmessage )
    {
    }
}