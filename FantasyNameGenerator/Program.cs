using Parser = FantasyNameGenerator.Utils.CommandLineParser;

// Very thin composition root - keeping logic out of Program.cs

var seededRandom = new SeededRandomProvider();
var ng = new SimpleNameGenerator(seededRandom);

var presenter = new CommandLinePresenter();

var request = Parser.Parse(args);

if (request is Parser.ParseResult.Failure failure)
{
    CommandLinePresenter.PrintError(failure.Message);
    Environment.Exit(1);
}

if (request is Parser.ParseResult.Help)
{
    CommandLinePresenter.PrintHelp();
    Environment.Exit(0);
}

if (request is Parser.ParseResult.Success success)
{
    var nameRequest = new NameRequest(
        success.Race,
        success.Length,
        success.Gender,
        success.NumberOfNames,
        success.Seed);

    var name = ng.Generate(nameRequest);

    presenter.PrintName(name);
    Environment.Exit(0);
}


