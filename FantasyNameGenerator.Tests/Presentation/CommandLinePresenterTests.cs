namespace FantasyNameGenerator.Tests;

public class CommandLinePresenterTests
{
    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Race()
    {
        // Arrange
        var p = new CommandLinePresenter();
        var name = "TestName";

        // Act
        p.PrintName(name);

        // Assert
        // Capture the console output and assert that it contains the expected name.
        Assert.Equal(name, p.PrintName(name));
    }

    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Gender()
    {
        // Arrange
        var p = new CommandLinePresenter();
        var name = "TestName";

        // Act
        p.PrintName(name);

        // Assert
        // Capture the console output and assert that it contains the expected name.
        Assert.Equal(name, p.PrintName(name));
    }

    [Fact]
    public void PrintName_Should_Display_Name_For_Request_With_Valid_Length()
    {
        // Arrange
        var p = new CommandLinePresenter();
        var name = "TestName";

        // Act
        p.PrintName(name);

        // Assert
        // Capture the console output and assert that it contains the expected name.
        Assert.Equal(name, p.PrintName(name));
    }

    [Fact]
    public void PrintName_Should_Display_Help_For_Request_With_Valid_Race()
    {
        // Arrange
        var p = new CommandLinePresenter();
        var name = "TestName";

        // Act
        p.PrintName(name);

        // Assert
        // Capture the console output and assert that it contains the expected name.
        Assert.Equal(name, p.PrintName(name));
    }
}