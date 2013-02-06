using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Hlin.Console.Specs.for_CommandLineParser
{
    public class when_validating_with_known_argument : given.a_command_line_parser
    {
        static bool result = false;
        static Mock<IProgramOptionHandler>  handler_mock;

        Establish context = () =>
        {
            handler_mock = new Mock<IProgramOptionHandler>();
            handler_mock.Setup(h => h.CanHandle(Moq.It.IsAny<ProgramOption>())).Returns(true);
            program_option_handler_manager_mock.SetupGet(c => c.Handlers).Returns(new[] {handler_mock.Object});
        };


        Because of = () => result = parser.HasValidArguments("/source:horse");

        It should_return_that_arguments_are_valid = () => result.ShouldBeTrue();
    }
}
