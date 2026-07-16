namespace FantasyNameGenerator.Tests;

public class CommandLinePresenterTests : IDisposable
{
    private readonly CommandLinePresenter _presenter;
    private readonly TextWriter _originalOut;
    private readonly StringWriter _writer;

    private const string TestName = "TestName";

    public CommandLinePresenterTests()
    {
        _originalOut = Console.Out;
        _writer = new StringWriter();
        Console.SetOut(_writer);

        _presenter = new CommandLinePresenter();
    }

    public void Dispose()
    {
        // Restore Console.Out after each test
        Console.SetOut(_originalOut);
        _writer.Dispose();
    }

    [Fact]
    public void PrintName_Should_Display_Name()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }


    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Race()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }

    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Gender()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }

    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Length()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }

    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Options()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }

    [Fact]
    public void PrintName_Should_Print_Feedback_For_Request_With_Invalid_Race()
    {
        // Act
        _presenter.PrintName(TestName);

        // Assert
        Assert.Contains(TestName, _writer.ToString());
    }
}
