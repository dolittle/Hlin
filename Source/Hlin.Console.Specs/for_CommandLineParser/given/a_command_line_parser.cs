using Machine.Specifications;
using Moq;

namespace Hlin.Console.Specs.for_CommandLineParser.given
{
    public class a_command_line_parser
    {
        protected static CommandLineParser parser;
        protected static Mock<IProgramOptionHandlerManager> program_option_handler_manager_mock;

        Establish context = () =>
        {
            program_option_handler_manager_mock = new Mock<IProgramOptionHandlerManager>();
            parser = new CommandLineParser(program_option_handler_manager_mock.Object);
        };
    }
}
