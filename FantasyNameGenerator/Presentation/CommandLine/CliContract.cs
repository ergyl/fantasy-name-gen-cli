namespace FantasyNameGenerator.Presentation.CommandLine;

/// <summary>
/// Defines the command-line interface (CLI) contract for the Fantasy Name Generator application, including arguments and options.
/// </summary>
public class CliContract
{
    public RootCommand Configure()
    {
        var rootCommand = new RootCommand("Generate random fantasy names")
        {
            RaceArg,
        };

        var allOptions = GetOptions();
        allOptions.ForEach(rootCommand.Add);

        return rootCommand;
    }

    /// <summary>
    /// Required positional argument
    /// </summary>
    public Argument<string> RaceArg { get; } = new("race")
    {
        Description = "Race (human, dwarven, orc, elf)",
        Arity = ArgumentArity.ExactlyOne
    };

    // Options
    public Option<bool> MaleOption { get; } = new("--male", "-m")
    {
        Description = "Generate male name(s)"
    };

    public Option<bool> FemaleOption { get; } = new("--female", "-f")
    {
        Description = "Generate male name(s)"
    };

    public Option<bool> ShortOption { get; } = new("--short", "-s")
    {
        Description = "Generate short name(s)"
    };

    public Option<bool> FullOption { get; } = new("--full", "-l")
    {
        Description = "Generate full name(s)"
    };

    public Option<int> NumberOption { get; } = new("--number", "-n")
    {
        Description = "Number of names to generate",
        HelpName = "count",
        Arity = ArgumentArity.ExactlyOne,
        DefaultValueFactory = _ => 1
    };

    public Option<long?> SeedOption { get; } = new("--seed")
    {
        Description = "Seed for reproducible generation",
        HelpName = "value",
        Arity = ArgumentArity.ExactlyOne,
    };

    public Option<string> VersionOption { get; } = new("--version", "-v")
    {
        Description = "Display the version of the application"
    };

    public List<Option> GetOptions()
    {
        return
        [
            MaleOption,
            FemaleOption,
            ShortOption,
            FullOption,
            NumberOption,
            SeedOption,
            //VersionOption,
        ];
    }
}