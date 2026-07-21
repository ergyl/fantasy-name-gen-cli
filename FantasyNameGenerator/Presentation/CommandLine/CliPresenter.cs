namespace FantasyNameGenerator.Presentation.CommandLine;

public class CliPresenter : IPresenter
{
    /// <summary>
    /// Prints an error message to the console in a user-friendly format to stderr, 
    /// so that it can be redirected separately from normal output.
    /// </summary>
    /// <param name="message">The error message to print.</param>
    public void PrintError(string message)
    {
        Console.Error.WriteLine($"Error: {message}");
        Console.Error.WriteLine("Enter --h or --help for usage information.");
    }

    /// <summary>
    /// Prints the generated names to the console in a user-friendly format to stdout.
    /// </summary>
    /// <param name="name">The name(s) to print.</param>
    public void PrintResult(List<string> names)
    {
        Console.Out.WriteLine();
        foreach (var name in names)
        {
            Console.Out.WriteLine(name);
        }
    }
}

