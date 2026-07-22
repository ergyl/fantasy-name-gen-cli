using FantasyNameGenerator.Presentation.CommandLine;
namespace FantasyNameGenerator.Tests;

public class CommandLinePresenterTests : IDisposable
{
    private readonly TextWriter _originalOut;
    private readonly TextWriter _originalError;
    private readonly StringWriter _stdout;
    private readonly StringWriter _stderr;
    private readonly CliPresenter _presenter;

    public CommandLinePresenterTests()
    {
        _originalOut = Console.Out;
        _stdout = new StringWriter();
        Console.SetOut(_stdout);

        _originalError = Console.Error;
        _stderr = new StringWriter();
        Console.SetError(_stderr);

        _presenter = new CliPresenter();
    }

    public void Dispose()
    {
        // Restore Console.Out and Console.Error after each test
        Console.SetOut(_originalOut);
        _stdout.Dispose();

        Console.SetError(_originalError);
        _stderr.Dispose();
    }

    [Fact]
    public void PrintResult_Should_Display_Name_In_Standard_Output()
    {
        // Arrange
        List<string> testNames = ["TestName"];

        // Act
        _presenter.PrintResult(testNames);

        // Assert
        var output = _stdout.ToString();
        Assert.Contains("TestName", output);
    }

    [Fact]
    public void PrintError_Should_Display_Error_Message_In_Standard_Error()
    {
        // Arrange
        string errorMessage = "This is a test error message.";

        // Act
        _presenter.PrintError(errorMessage);

        // Assert
        var output = _stderr.ToString();
        Assert.Contains("Error: This is a test error message.", output);
        Assert.Contains("Enter --h or --help for usage information.", output);
    }
}
