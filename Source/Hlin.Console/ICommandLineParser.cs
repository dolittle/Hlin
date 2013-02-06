using System.Collections.Generic;

namespace Hlin.Console
{
    public interface ICommandLineParser
    {
        ProgramOptions Parse(params string[] arguments);
        bool HasValidArguments(params string[] arguments);
    }
}
