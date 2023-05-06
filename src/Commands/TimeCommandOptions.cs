using System.ComponentModel;
using Spectre.Console.Cli;

namespace FileCleaner.Commands;

[Description("按时间操作相关参数")]
internal class TimeCommandOptions : CommandSettings
{
    [Description("清理指定天数之前的文件（按照文件最后修改时间判断）")]
    [CommandOption("--days")]
    public int? DaysBefore { get; set; }

    [Description("要清理的绝对路径，多个路径请使用分号（;）分割（中英文分号都可以），如path1;path2;path3")]
    [CommandOption("--paths")]
    public string Paths { get; set; }

    [Description("是否递归处理路径下的文件夹，默认为false")]
    [CommandOption("--rec")]
    public bool? Recursion { get; set; }
}
