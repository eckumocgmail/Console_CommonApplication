using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ConfigurationProvider
{
    public static string GetWrk()
        => System.IO.Directory.GetCurrentDirectory();
    public static IEnumerable<string> GetFiles()
        => GetWrk().GetFiles();
    public static IEnumerable<string> GetDlls()
        => GetWrk().GetFilesInAllSubdirectories("*.dll");
    public static IEnumerable<string> GetJsonFiles()
        => GetWrk().GetFiles().Where(f => f.ToLower().EndsWith(".json"));
    
    public static IEnumerable<string> GetIniFiles()
        => GetWrk().GetFiles().Where(f => f.ToLower().EndsWith(".ini"));

    public static IConfiguration FromDirectory(string DirPath)
    {
        var builder = new ConfigurationBuilder();

        foreach (string file in GetJsonFiles())
        {
            builder.AddJsonFile(file);

        }
        return builder.Build();
    }
}
 
