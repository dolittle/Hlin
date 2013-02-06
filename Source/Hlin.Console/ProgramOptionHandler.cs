using System;
using System.Linq;

namespace Hlin.Console
{
    public abstract class ProgramOptionHandler : IProgramOptionHandler
    {
        public abstract string Name { get; }
        public abstract string[] Commands { get; }
        public abstract string Description { get; }

        public abstract void Handle(ProgramOptions options, ProgramOption option);

        public virtual bool CanHandle(ProgramOption option)
        {
            return Commands.Any(c=>c.ToLowerInvariant() == option.Command.ToLowerInvariant());
        }
    }
}
