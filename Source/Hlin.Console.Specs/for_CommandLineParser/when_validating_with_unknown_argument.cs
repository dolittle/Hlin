using Machine.Specifications;

namespace Hlin.Console.Specs.for_CommandLineParser
{
    public class when_validating_with_unknown_argument : given.a_command_line_parser
    {
        static bool result = true;

        Because of = () => result = parser.HasValidArguments("/something:horse");

        It should_return_that_arguments_are_not_valid = () => result.ShouldBeFalse();
    }
}
