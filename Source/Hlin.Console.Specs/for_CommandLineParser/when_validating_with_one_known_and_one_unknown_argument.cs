using Machine.Specifications;

namespace Hlin.Console.Specs.for_CommandLineParser
{
    public class when_validating_with_one_known_and_one_unknown_argument : given.a_command_line_parser
    {
        static bool result = true;

        Because of = () => result = parser.HasValidArguments("/source:horse","/something:else");

        It should_return_that_arguments_are_not_valid = () => result.ShouldBeFalse();
    }
}
