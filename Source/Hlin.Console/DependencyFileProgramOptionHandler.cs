using System;

namespace Hlin.Console
{
    public class DependencyFileProgramOptionHandler : ProgramOptionHandler
    {
        public override string Name { get { return "Dependency File"; } }
        public override string[] Commands
        {
            get { return new[] { "DependencyFile", "d" }; }
        }

        public override string Description { get { return "The dependency file in the format of Juicers dependency files";  } }

        public override void Handle(ProgramOptions options, ProgramOption option)
        {
            options.DependencyFile = option.Value;
        }
    }
}
