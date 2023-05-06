using System.ComponentModel;
using Spectre.Console.Cli;

namespace FileCleaner.Commands;
internal class DefaultCommandOptions : CommandSettings
{
    [Description("显示版本")]
    [CommandOption("-v|--version")]
    public bool Version { get; set; }
}
