using System;
using System.Collections.Generic;
using System.Linq;

namespace Hlin.Console
{
    public class CommandLineParser : ICommandLineParser
    {
        IProgramOptionHandlerManager _programOptionHandlerManager;

        public CommandLineParser(IProgramOptionHandlerManager programOptionHandlerManager)
        {
            _programOptionHandlerManager = programOptionHandlerManager;
        }

        public ProgramOptions Parse(params string[] arguments)
        {
            var programOptions = new ProgramOptions();
            foreach (var argument in arguments)
            {
                if (argument.StartsWith("/"))
                {
                    var programOption = ProgramOption.Parse(argument);
                    foreach (var handler in _programOptionHandlerManager.Handlers.Where(h => h.CanHandle(programOption)))
                        handler.Handle(programOptions, programOption);
                }
            }

            return programOptions;
        }
       

        public bool HasValidArguments(params string[] arguments)
        {
            return arguments.All(a=>_programOptionHandlerManager.Handlers.Any(h=>h.CanHandle(ProgramOption.Parse(a))));
        }
    }
}
