using System.Collections.Generic;

namespace Hlin.Console
{
    public class ProgramOptionHandlerManager : IProgramOptionHandlerManager
    {
        IProgramOptionHandler[] _handlers = new IProgramOptionHandler[] {
            new DependencyFileProgramOptionHandler(),
            new TargetFileProgramOptionHandler()
        };

        public IEnumerable<IProgramOptionHandler> Handlers { get { return _handlers; } }
    }
}
