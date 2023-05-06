using FileCleaner.Definitions.Constants;
using Newtonsoft.Json;

namespace FileCleaner.Utility;

internal class ConfigHelper
{
    /// <summary>
    /// 获取配置文件
    /// </summary>
    /// <typeparam name="T">配置文件类型</typeparam>
    /// <returns>配置文件对象</returns>
    public static T? GetConfig<T>()
    {
        var configName = Path.GetFullPath(Config.ConfigName);
        if (!File.Exists(configName))
        {
            throw new FileNotFoundException(configName);
        }

        var serializer = new JsonSerializer();
        using var reader = new StreamReader(configName);
        using JsonReader jsonReader = new JsonTextReader(reader);
        var result = serializer.Deserialize<T>(jsonReader);
        return result;
    }
}
