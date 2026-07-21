using FantasyNameGenerator.Presentation.CommandLine;

namespace FantasyNameGenerator.Tests;

public class CommandLineValidatorTests
{
    private const string TestName = "TestName";

    [Fact]
    public void Validate_Should_Return_Valid_Result_For_Request_With_Valid_Data()
    {
        // Act
        var result = CliRequestValidator.Validate(new CliRequest
        {
            Race = "Human",
            Male = true,
            Female = false,
            Short = true,
            Full = false,
            NumberOfNames = 1,
            Seed = null
        });

        // Assert
        Assert.True(result.IsValid);
        Assert.True(result.Value);
        Assert.Null(result.ErrorMessage);
    }
    [Fact]
    public void Validate_Should_Return_Invalid_Result_For_Request_With_Multiple_Gender_Options()
    {
        var request = new CliRequest
        {
            Race = "Human",
            Male = true,
            Female = true,
            Short = false,
            Full = true,
            NumberOfNames = 1,
            Seed = null
        };

        // Act
        var result = CliRequestValidator.Validate(request);

        // Assert 
        Assert.False(result.IsValid, "Invalid result expected when both --male and");
        Assert.False(result.Value, "Value should be false for invalid request.");
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public void Validate_Should_Return_Invalid_Result_For_Request_With_Multiple_Length_Options()
    {
        var request = new CliRequest
        {
            Race = "Human",
            Male = true,
            Female = false,
            Short = true,
            Full = true,
            NumberOfNames = 1,
            Seed = null
        };

        // Act
        var result = CliRequestValidator.Validate(request);

        // Assert 
        Assert.False(result.IsValid, "Invalid result expected when both --full and --short are specified.");
        Assert.False(result.Value, "Value should be false for invalid request.");
        Assert.NotNull(result.ErrorMessage);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(1501)]
    public void Validate_Should_Return_Invalid_Result_For_Request_With_NumberOfNames_Option_Outside_Valid_Range(int numberOfNames)
    {
        var request = new CliRequest
        {
            Race = "Human",
            Male = true,
            Female = false,
            Short = true,
            Full = true,
            NumberOfNames = numberOfNames,
            Seed = null
        };

        // Act
        var result = CliRequestValidator.Validate(request);

        // Assert 
        Assert.False(result.IsValid, "Invalid result expected when numberOfNames is outside the valid range.");
        Assert.False(result.Value, "Value should be false for invalid request.");
        Assert.NotNull(result.ErrorMessage);
    }
}