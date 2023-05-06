using FileCleaner.Commands;
using Spectre.Console.Cli;

namespace FileCleaner;

internal class Program
{
    static int Main(string[] args)
    {
        var app = new CommandApp();
        app.SetDefaultCommand<DefaultCommand>();

        // 配置程序
        app.Configure(config =>
        {
            // 初始化
            config.SetApplicationName("cln");
            config.UseStrictParsing();

            // 添加命令
            config.AddCommand<TimeCommand>("time");
        });

        // 执行控制台程序
        return app.Run(args);
    }
}
