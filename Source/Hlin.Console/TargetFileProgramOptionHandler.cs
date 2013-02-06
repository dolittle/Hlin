using System;

namespace Hlin.Console
{
    public class TargetFileProgramOptionHandler : ProgramOptionHandler
    {
        public override string Name { get { return "Target File"; } }
        public override string[] Commands
        {
            get { return new[] { "TargetFile", "t" }; }
        }

        public override string Description { get { return "The result target file";  } }

        public override void Handle(ProgramOptions options, ProgramOption option)
        {
            options.TargetFile = option.Value;
        }
    }
}
