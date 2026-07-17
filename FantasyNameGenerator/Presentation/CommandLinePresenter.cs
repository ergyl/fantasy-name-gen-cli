namespace FantasyNameGenerator.Presentation;

public class CommandLinePresenter
{

    public static void PrintError(string message)
    {
        Console.WriteLine($"Error: {message}");
        Console.WriteLine("Enter --h or --help for usage information.");
    }
    public static void PrintHelp(string message?= null)
    {
        Console.WriteLine(@"==========================
        Fantastic Fantasy Name Generator
        ==========================
        Command shape: ff-name <race> [gender] [length] [options]
        Example: ff-name human -m -s
        ==========================
        Arguments:
        <category> 	 Name category (human, elf, dwarf, orc)
        
        Options:
        -m, --male              Generate male names*
        -f, --female            Generate female names*
        -s, --short             Generate short names
        -l, --full              Generate full names (first names + surnames)
        -n, --number <count>    Number of names to generate
        --seed <value>      Seed for reproducible generation
        -h, --help              Show help
");
    }

    public void PrintName(string name)
    {
        Console.WriteLine();
        Console.WriteLine(name);
    }
}

