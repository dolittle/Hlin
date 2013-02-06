namespace Hlin.Console
{
    public interface IProgramOptionHandler
    {
        string Name { get; }
        string[] Commands { get; }
        string Description { get; }

        void Handle(ProgramOptions options, ProgramOption option);
        bool CanHandle(ProgramOption option);
    }
}
