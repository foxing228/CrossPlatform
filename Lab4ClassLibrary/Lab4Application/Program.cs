namespace Lab4Application;
using McMaster.Extensions.CommandLineUtils;
using Lab4ClassLibrary;

public class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication
        {
            Name = "Lab4",
            Description = "Lab 4 for CrossPlatform Programming"
        };

        LabsResolver resolver = null;
        
        app.HelpOption(inherited: true);

        app.Command("version", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                Console.WriteLine("Author: Prokhorchuk Dmytro, Group IPZ-43");
                Console.WriteLine("Version - 1.0.0");
            });
        });
        
        app.Command("run", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                Console.WriteLine("Specify a lab to execute(lab1, lab2 or lab3)");
            });
        
            configCmd.Command("lab1", setCmd =>
            {
                setCmd.Description = "Execute lab1";
                var input = setCmd.Option("--input", "input file", CommandOptionType.SingleValue);
                var output = setCmd.Option("--output", "output file", CommandOptionType.SingleValue);
                
                setCmd.OnExecute(() =>
                {
                    if (input.HasValue() || output.HasValue())
                    {
                        resolver = new Lab1Resolver(input.Value(), output.Value());
                    }
                    else if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAB_PATH")))
                    {
                        var filesPath = Environment.GetEnvironmentVariable("LAB_PATH");
                        resolver = new Lab1Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else if (!String.IsNullOrEmpty(Environment.CurrentDirectory))
                    {
                        var filesPath = Environment.CurrentDirectory;
                        resolver = new Lab1Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else
                    {
                        throw new Exception("Input and output files does not exist");
                    }
                    resolver.resolveLab();
                });
            });
            
            configCmd.Command("lab2", setCmd =>
            {
                setCmd.Description = "Execute lab2";
                var input = setCmd.Option("--input", "input file", CommandOptionType.SingleValue);
                var output = setCmd.Option("--output", "output file", CommandOptionType.SingleValue);
        
                setCmd.OnExecute(() =>
                {
                    if (input.HasValue() || output.HasValue())
                    {
                        resolver = new Lab2Resolver(input.Value(), output.Value());
                    }
                    else if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAB_PATH")))
                    {
                        var filesPath = Environment.GetEnvironmentVariable("LAB_PATH");
                        resolver = new Lab2Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else if (!String.IsNullOrEmpty(Environment.CurrentDirectory))
                    {
                        var filesPath = Environment.CurrentDirectory;
                        resolver = new Lab2Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else
                    {
                        throw new Exception("Input and output files does not exist");
                    }
                    resolver.resolveLab();
                });
            });
            
            configCmd.Command("lab3", setCmd =>
            {
                setCmd.Description = "Execute lab3";
                var input = setCmd.Option("--input", "input file", CommandOptionType.SingleValue);
                var output = setCmd.Option("--output", "output file", CommandOptionType.SingleValue);
                
                setCmd.OnExecute(() =>
                {
                    if (input.HasValue() || output.HasValue())
                    {
                        resolver = new Lab3Resolver(input.Value(), output.Value());
                    }
                    else if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAB_PATH")))
                    {
                        var filesPath = Environment.GetEnvironmentVariable("LAB_PATH");
                        resolver = new Lab3Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else if (!String.IsNullOrEmpty(Environment.CurrentDirectory))
                    {
                        var filesPath = Environment.CurrentDirectory;
                        resolver = new Lab3Resolver($"{filesPath}/Input.txt", $"{filesPath}/Output.txt");
                    }
                    else
                    {
                        throw new Exception("Input and output files does not exist");
                    }
                    resolver.resolveLab();
                });
            });
        });
        
        app.Command("set-path", setCmd =>
        {
            setCmd.Description = "Set labs path";
            var path = setCmd.Option("--path", "path", CommandOptionType.SingleValue).IsRequired();

            setCmd.OnExecute(() =>
            {
                Environment.SetEnvironmentVariable("LAB_PATH", $"{path.Value()}", EnvironmentVariableTarget.User);
            });
        });
        
        app.OnExecute(() =>
        {
            Console.WriteLine("Launching lab-4 application");
            app.ShowHelp();
            return 1;
        });
        
        return app.Execute(args);
    }
}