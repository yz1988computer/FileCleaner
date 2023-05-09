using FileCleaner.Definitions.Constants;
using Newtonsoft.Json;

namespace FileCleaner.Utility;

internal class ConfigHelper
{
    /// <summary>
    /// 获取配置文件
    /// </summary>
    /// <param name="configPath">配置文件路径，如果不指定，将从程序根目录查找名称为config.json的配置文件</param>
    /// <typeparam name="T">配置文件类型</typeparam>
    /// <returns>配置文件对象</returns>
    public static T? GetConfig<T>(string configPath = "")
    {
        if (string.IsNullOrEmpty(configPath))
        {
            configPath = Path.GetFullPath(Config.ConfigName);
        }

        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException($"未找到配置文件:{configPath}");
        }

        var serializer = new JsonSerializer();
        using var reader = new StreamReader(configPath);
        using JsonReader jsonReader = new JsonTextReader(reader);
        var result = serializer.Deserialize<T>(jsonReader);
        return result;
    }
}
