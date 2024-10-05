using System.CommandLine;
using System.IO;
using System.Linq;

namespace WindowResizer.CLI.Commands
{
    public class ConfigOption : Option<FileInfo>
    {
        public ConfigOption() : base(
            aliases: new[]
            {
                "--config",
                "-c"
            },
            description: "Config file path, use current config file if omitted.",
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return null;
                }

                var filePath = result.Tokens.Single().Value;
                return new FileInfo(filePath);
            })
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class ProfileOption : Option<string>
    {
        public ProfileOption() : base(
            aliases: new[]
            {
                "--profile",
                "-P"
            },
            description: "Profile name, use current profile if omitted.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class ProcessOption : Option<string>
    {
        public ProcessOption() : base(
            aliases: new[]
            {
                "--process",
                "-p"
            },
            description: "Process name, use foreground process if omitted.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class TitleOption : Option<string>
    {
        public TitleOption() : base(
            aliases: new[]
            {
                "--title",
                "-t"
            },
            description: "Process title, all windows of the process will be resized if not specified.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class WidthOption : Option<int>
    {
        public WidthOption() : base(
            aliases: new[]
            {
                "--width",
                "-w"
            },
            description: "Window width.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class SizeOption : Option<int[]>
    {
        public SizeOption() : base(
            aliases: new[]
            {
                "--size",
                "-s"
            },
            description: "Window size.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = true;
        }
    }

    public class PosOption : Option<int[]>
    {
        public PosOption() : base(
            aliases: new[]
            {
                "--pos",
                "-i"
            },
            description: "Window pos.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = true;
        }
    }

    public class HeightOption : Option<int>
    {
        public HeightOption() : base(
            aliases: new[]
            {
                "--height",
                "-h"
            },
            description: "Window height.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class XOption : Option<int>
    {
        public XOption() : base(
            aliases: new[]
            {
                "--pos-x",
                "-x"
            },
            description: "Window pos x.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class YOption : Option<int>
    {
        public YOption() : base(
            aliases: new[]
            {
                "--pos-y",
                "-y"
            },
            description: "Window pos y.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }

    public class VerboseOption : Option<bool>
    {
        public VerboseOption() : base(
            aliases: new[]
            {
                "--verbose",
                "-v"
            },
            description: "Show more details.")
        {
            IsRequired = false;
            AllowMultipleArgumentsPerToken = false;
        }
    }
}
