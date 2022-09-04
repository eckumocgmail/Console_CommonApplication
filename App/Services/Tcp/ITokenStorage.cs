using System.Threading.Tasks;

[Icon("")]
[Description("Контроллер предназначен для .")]
public interface ITokenStorage 
{
     
    //public Task<string> GetAsync();
    //public Task SetAsync(string value);
    public string Get();
    public void Set(string token);
}
