using Machine.Specifications;

namespace Hlin.Console.Specs.for_ProgramOption
{
    public class when_parsing_an_argument_with_value_surrounded_by_quotes
    {
        static ProgramOption result;

        Because of = () => result = ProgramOption.Parse("/Hello=\"World\"");

        It should_have_correct_command = () => result.Command.ShouldEqual("hello");
        It should_have_correct_value = () => result.Value.ShouldEqual("World");
    }
}
