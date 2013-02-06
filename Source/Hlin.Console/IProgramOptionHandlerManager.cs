using System.Collections.Generic;

namespace Hlin.Console
{
    public interface IProgramOptionHandlerManager
    {
        IEnumerable<IProgramOptionHandler> Handlers { get; }
    }
}
