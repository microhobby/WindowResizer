using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using WindowResizer.Base;
using WindowResizer.CLI.Utils;

namespace WindowResizer.CLI.Commands
{
    internal class ResizeCommand : Command
    {
        public ResizeCommand() : base("resize", "Resize window by process and window title.")
        {
            var configOption = new ConfigOption();
            AddOption(configOption);
            var profileOption = new ProfileOption();
            AddOption(profileOption);
            var processOption = new ProcessOption();
            AddOption(processOption);
            var titleOption = new TitleOption();
            AddOption(titleOption);
            var verboseOption = new VerboseOption();
            AddOption(verboseOption);
            var sizeOption = new SizeOption();
            AddOption(sizeOption);;
            var posOption = new PosOption();
            AddOption(posOption);

            this.SetHandler(
                (config, profile, process, title, verbose, size, pos) =>
                {
                    void VerboseInfo(List<WindowCmd.TargetWindow> lists)
                    {
                        if (verbose)
                        {
                            Verbose(lists);
                        }
                    }

                    var success = WindowCmd.Resize(
                        config?.FullName,
                        profile,
                        process,
                        title,
                        size[0],
                        size[1],
                        pos[0],
                        pos[1],
                        Output.Error,
                        VerboseInfo
                    );

                    if (!success) {
                        System.Console.WriteLine("FAILED");
                    }

                    var ret = Task.FromResult(success ? 0 : 1);
                    return ret;
                },
                configOption,
                profileOption,
                processOption,
                titleOption,
                verboseOption,
                sizeOption,
                posOption
            );
        }

        private static void Verbose(List<WindowCmd.TargetWindow> lists)
        {
            if (!lists.Any())
            {
                Output.Echo("No windows resized.");
                return;
            }

            var table = new Table();
            table.AddColumn(new TableColumn("Handle"));
            table.AddColumn(new TableColumn("Process"));
            table.AddColumn(new TableColumn("Title"));
            table.AddColumn(new TableColumn("Success").Centered());
            table.AddColumn(new TableColumn("Error"));
            foreach (var item in lists)
            {
                var result = string.IsNullOrEmpty(item.Result) ? "[green]Y[/]" : "[red]N[/]";
                table.AddRow(item.Handle.ToString(), $"[green]{item.ProcessName}[/]", item.Title ?? string.Empty, result, $"[red]{item.Result}[/]");
            }

            table.Border(TableBorder.Square);
            table.Alignment(Justify.Left);
            AnsiConsole.Write(table);
        }
    }
}
