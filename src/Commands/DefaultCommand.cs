using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Spectre.Console.Cli;

namespace FileCleaner.Commands;
internal class DefaultCommand : Command<DefaultCommandOptions>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] DefaultCommandOptions settings)
    {
        var version = typeof(Program).Assembly
            .GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
        Console.WriteLine($"当前程序版本:{version}");
        return 0;
    }
}
