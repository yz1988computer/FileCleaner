using Newtonsoft.Json;

namespace FileCleaner.Configs;

[Serializable]
internal class TimeJsonConfig
{
    [JsonProperty("daysBefore")]
    public int DaysBefore { get; set; }

    [JsonProperty("paths")]
    public string Paths { get; set; }

    [JsonProperty("rec")]
    public bool Recursion { get; set; }
}
