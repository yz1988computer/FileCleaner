using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using FileCleaner.Configs;
using FileCleaner.Definitions.Constants;
using FileCleaner.Utility;
using Spectre.Console;
using Spectre.Console.Cli;

namespace FileCleaner.Commands;

/// <summary>
/// 按时间操作命令
/// </summary>
internal class TimeCommand : Command<TimeCommandOptions>
{
    private const string ConfigName = Config.ConfigName;

    public override int Execute(CommandContext context
        , [NotNull] TimeCommandOptions settings)
    {
        var config = ConfigHelper.GetConfig<TimeConfig>()!.Config;
        MergeConfig(config, settings);
        var paths = config.Paths.Split(StringSplit.Semicolon
            , StringSplitOptions.RemoveEmptyEntries);
        var date = DateTime.Now.AddDays(config.DaysBefore * -1);
        foreach (var path in paths)
        {
            DelFiles(path, config.Recursion, date);
        }

        return 0;
    }

    private void MergeConfig(TimeJsonConfig jsonConfig, TimeCommandOptions settings)
    {
        // 把命令行参数合并到配置文件里（优先使用命令行参数）
        if (settings.Recursion.HasValue)
        {
            jsonConfig.Recursion = settings.Recursion.Value;
        }

        if (settings.DaysBefore.HasValue)
        {
            jsonConfig.DaysBefore = settings.DaysBefore.Value;
        }

        if (!string.IsNullOrEmpty(settings.Paths))
        {
            jsonConfig.Paths = settings.Paths;
        }
    }

    private void DelFiles(string path, bool recursion, DateTime date)
    {
        var files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            var lastModifyDate = File.GetLastWriteTime(file);
            if (DateTime.Compare(date, lastModifyDate) > 0)
            {
                // 过期
                File.Delete(file);
            }
        }

        if (recursion)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                DelFiles(directory, recursion, date);
            }
        }
    }
}
