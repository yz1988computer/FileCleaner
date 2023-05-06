using Newtonsoft.Json;

namespace FileCleaner.Configs;
internal sealed class TimeConfig
{
    [JsonProperty("time")]
    public TimeJsonConfig Config { get; set; }
}
