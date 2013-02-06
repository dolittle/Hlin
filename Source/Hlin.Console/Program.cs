using System;
using System.IO;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Hlin.Console
{
    class Program
    {
        static IKernel Kernel;

        static Program()
        {
            Kernel = new StandardKernel();
            Kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().BindDefaultInterface());
        }

        static int Main(string[] args)
        {
            var commandLineParser = Kernel.Get<ICommandLineParser>();
            if (!commandLineParser.HasValidArguments(args))
            {
                ShowHelp();
                return 1;
            }
            var programOptions = commandLineParser.Parse(args);
            if (!programOptions.IsValid)
            {
                ShowHelp();
                return 1;
            }


            System.Console.WriteLine("Hlin - (C)2013 Dolittle\n\n");
            System.Console.WriteLine("Using dependency file : " + programOptions.DependencyFile);
            System.Console.WriteLine("Outputting to : " + programOptions.TargetFile);

            var targetDirectory = Path.GetDirectoryName(programOptions.TargetFile);
            if (string.IsNullOrEmpty(targetDirectory))
                targetDirectory = Directory.GetCurrentDirectory();
            var targetFile = Path.Combine(targetDirectory, programOptions.TargetFile);

            var first = true;
            var dependencies = File.ReadAllLines(programOptions.DependencyFile);

            var count = 0;
            foreach (var dependency in dependencies)
            {
                var elements = dependency.Split(' ');
                if (elements.Length == 2)
                {
                    if( elements[0] == "@depends" ) {
                        var directory = Path.GetDirectoryName(programOptions.DependencyFile);
                        if( string.IsNullOrEmpty(directory) ) 
                            directory = Directory.GetCurrentDirectory();

                        var sourceFile = Path.Combine(directory, elements[1]);
                        var text = File.ReadAllText(sourceFile);

                        if (first)
                        {
                            File.WriteAllText(targetFile, text);
                            first = false;
                        } 
                        else 
                            File.AppendAllText(targetFile, text);

                        System.Console.Write(".");
                        count++;
                    }
                }
            }

            System.Console.WriteLine("\n\n{0} files handled\n", count);

            return 0;
        }

        static void ShowHelp()
        {
            var handlerManager = Kernel.Get<IProgramOptionHandlerManager>();
            System.Console.WriteLine("Usage : \n");
            System.Console.WriteLine("{0} <options>\n\n", Assembly.GetEntryAssembly().GetName().Name);
            System.Console.WriteLine("Options are:");
            foreach (var handler in handlerManager.Handlers)
                System.Console.WriteLine("/{0}:value\t{1}", handler.Name, handler.Description);

            System.Console.WriteLine("\n");
        }
    }
}
