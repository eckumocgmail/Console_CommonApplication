using Microsoft.Extensions.Configuration;

using System.IO;

public static class ConfigurationExtensions
{
    public static IConfigurationBuilder AddDirectory( this IConfigurationBuilder builder, string path)
    {
        foreach(string file in System.IO.Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
        {
            if (file.ToLower().EndsWith(".ini"))
            {
                builder.Info("В конфигурацию добавлен файл: " + file);
                builder.AddIniFile(file);
            }
            if (file.ToLower().EndsWith(".json"))
            {
                builder.Info("В конфигурацию добавлен файл: "+file);
                builder.AddJsonFile(file);
            }
        }
        return builder;
    }


}
