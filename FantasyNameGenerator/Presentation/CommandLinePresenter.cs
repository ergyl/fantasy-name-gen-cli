namespace FantasyNameGenerator.Presentation;

public class CommandLinePresenter
{

    public static void PrintError(string message)
    {
        Console.WriteLine($"Error: {message}");
        Console.WriteLine("Enter --h or --help for usage information.");
    }
    public static void PrintHelp()
    {
        Console.WriteLine(@"==========================
        Fantastic Fantasy Name Generator
        ==========================
        Command shape: ff-name <race> [options]
        Example: ff-name orc -m -s (orc male short name)
        ==========================
     ```
     Required positional argument:
     <race>              Race (human, dwarven, orc, elf)
    
    Options:
    -m, --male              Male names
    -f, --female            Female names
    -s, --short name        Short names
    -l, --full name         Full names (first names + surnames)
    -n, --number <count>    Number of names to generate
    --seed <value>          Seed for reproducible generation
    -h, --help              Show help
```
");
    }

    public void PrintName(string name)
    {
        Console.WriteLine();
        Console.WriteLine(name);
    }
}

