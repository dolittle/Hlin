
namespace Hlin.Console
{
    public class ProgramOption
    {
        public string Command { get; set; }
        public string Value { get; set; }

        public static ProgramOption Parse(string argument)
        {
            var programOption = new ProgramOption();
            var colonIndex = argument.IndexOf('=');
            if (colonIndex > 0)
            {
                var parts = new[] {
                        argument.Substring(1,colonIndex-1),
                        argument.Substring(colonIndex+1)
                    };
                programOption.Command = parts[0].ToLowerInvariant();
                programOption.Value = parts[1].Replace("\"", string.Empty).Replace("'", string.Empty);
            }
            return programOption;
        }
    }
}
