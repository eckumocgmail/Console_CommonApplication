using System;

public interface IFilesEntityFasade<T>: IEntityFasade<T> where T : BaseEntity
{
    public void Save(int id, string file);
    public void Load(string file);
    public void Listen(string file, Action<System.IO.FileSystemEventArgs> onmessage);
}
