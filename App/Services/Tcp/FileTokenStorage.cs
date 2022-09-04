using System.Threading.Tasks;

[Icon("")]
[Description("Контроллер предназначен для .")]
public class FileTokenStorage: ITokenStorage
{
    public FileTokenStorage()
    {
        if(System.IO.File.Exists(nameof(ITokenStorage))==false)
            System.IO.File.Create(nameof(ITokenStorage));
    }

    public string Get ()
    {
     
        return System.IO.File.ReadAllText(nameof(ITokenStorage));
    }
    public void Set(string value)
    {
        System.IO.File.WriteAllText(nameof(ITokenStorage), value);

    }
}
