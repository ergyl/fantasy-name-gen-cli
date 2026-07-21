using FantasyNameGenerator.Presentation;

namespace FantasyNameGenerator.Application;

/// <summary>
/// The main application class that orchestrates the flow of the Fantasy Name Generator CLI application. 
/// It handles command-line input, validation, mapping to domain requests, and invoking the name generation logic.
/// </summary>
public class FantasyNameGeneratorApp
{
    private readonly CliContract _cliContract;
    private readonly IPresenter _presenter;
    private readonly INameGenerator _generator;

    private const int ExitCodeSuccess = 0;
    private const int ExitCodeError = 1;

    public FantasyNameGeneratorApp(CliContract cliContract, IPresenter presenter, INameGenerator generator)
    {
        _cliContract = cliContract;
        _presenter = presenter;
        _generator = generator;
    }

    public int Run(string[] args)
    {
        var rootCommand = _cliContract.Configure();

        // Set the action to be executed when command line arguments are parsed successfully
        rootCommand.SetAction(parseResult =>
        {
            if (parseResult.Errors.Any())
            {
                foreach (var error in parseResult.Errors)
                {
                    _presenter.PrintError(error.Message);
                }
                return ExitCodeError;
            }


            var cliRequest = new CliRequest
            {
                Race = parseResult.GetValue(_cliContract.RaceArg)!,
                Male = parseResult.GetValue(_cliContract.MaleOption),
                Female = parseResult.GetValue(_cliContract.FemaleOption),
                Short = parseResult.GetValue(_cliContract.ShortOption),
                Full = parseResult.GetValue(_cliContract.FullOption),
                NumberOfNames = parseResult.GetValue(_cliContract.NumberOption),
                Seed = parseResult.GetValue(_cliContract.SeedOption)
            };

            var validation = CliRequestValidator.Validate(cliRequest);

            if (!validation.IsValid)
            {
                _presenter.PrintError(validation.ErrorMessage!);
                return ExitCodeError;
            }

            var domainRequest = CliRequestMapper.Map(cliRequest);

            if (!domainRequest.IsValid)
            {
                _presenter.PrintError(domainRequest.ErrorMessage!);
                return ExitCodeError;
            }

            var result = _generator.Generate(domainRequest.Value!);
            _presenter.PrintResult(result);

            return ExitCodeSuccess;
        });

        var parseResult = rootCommand.Parse(args);

        // Run command action and return the exit code
        return parseResult.Invoke();
    }
}
