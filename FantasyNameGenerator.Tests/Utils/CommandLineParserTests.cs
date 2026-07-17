namespace FantasyNameGenerator.Tests;

public class CommandLineParserTests
{
    [Theory]
    [InlineData(new[] { "human" }, Race.Human)]
    [InlineData(new[] { "dwarven" }, Race.Dwarven)]
    [InlineData(new[] { "elf" }, Race.Elf)]
    [InlineData(new[] { "orc" }, Race.Orc)]
    public void Parse_WithValidRaceOnly_ReturnsSuccess(
        string[] args,
        Race expectedRace)
    {
        // Arrange & Act
        var result = CommandLineParser.Parse(args);

        // Assert
        Assert.IsType<CommandLineParser.ParseResult.Success>(result);
        var success = (CommandLineParser.ParseResult.Success)result;

        Assert.Equal(expectedRace, success.Race);

        Assert.Null(success.Length);
        Assert.Null(success.NumberOfNames);
        Assert.Null(success.Seed);
    }

    [Theory]
    [InlineData(new[] { "human", "--female" }, Race.Human, Gender.Female)]
    [InlineData(new[] { "human", "-f" }, Race.Human, Gender.Female)]
    [InlineData(new[] { "dwarven", "--male" }, Race.Dwarven, Gender.Male)]
    [InlineData(new[] { "dwarven", "-m" }, Race.Dwarven, Gender.Male)]
    [InlineData(new[] { "orc", "--female" }, Race.Orc, Gender.Female)]
    [InlineData(new[] { "orc", "-f" }, Race.Orc, Gender.Female)]
    [InlineData(new[] { "elf", "--male" }, Race.Elf, Gender.Male)]
    [InlineData(new[] { "elf", "-m" }, Race.Elf, Gender.Male)]
    public void Parse_WithValidRaceAndGender_ReturnsSuccess(
     string[] args,
     Race expectedRace,
     Gender expectedGender)
    {
        // Arrange & Act
        var result = CommandLineParser.Parse(args);

        // Assert
        Assert.IsType<CommandLineParser.ParseResult.Success>(result);
        var success = (CommandLineParser.ParseResult.Success)result;

        Assert.Equal(expectedRace, success.Race);
        Assert.Equal(expectedGender, success.Gender);

        Assert.Null(success.NumberOfNames);
        Assert.Null(success.Seed);
    }

    [Theory]
    [InlineData(new[] { "human", "--short" }, Race.Human, Length.Short)]
    [InlineData(new[] { "human", "-s" }, Race.Human, Length.Short)]
    [InlineData(new[] { "dwarven", "--full" }, Race.Dwarven, Length.Long)]
    [InlineData(new[] { "dwarven", "-l" }, Race.Dwarven, Length.Long)]
    [InlineData(new[] { "orc", "--full" }, Race.Orc, Length.Long)]
    [InlineData(new[] { "orc", "-l" }, Race.Orc, Length.Long)]
    [InlineData(new[] { "elf", "short" }, Race.Elf, Length.Short)]
    [InlineData(new[] { "elf", "-s" }, Race.Elf, Length.Short)]
    public void Parse_WithValidRaceAndLength_ReturnsSuccess(
     string[] args,
     Race expectedRace,
     Length? expectedLength)
    {
        // Arrange & Act
        var result = CommandLineParser.Parse(args);

        // Assert
        Assert.IsType<CommandLineParser.ParseResult.Success>(result);
        var success = (CommandLineParser.ParseResult.Success)result;

        Assert.Equal(expectedRace, success.Race);
        Assert.Equal(expectedLength, success.Length);

        Assert.Null(success.Gender);
        Assert.Null(success.NumberOfNames);
        Assert.Null(success.Seed);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("invalid")]
    [InlineData("Human")]
    [InlineData("humman")]
    [InlineData(" human")]
    [InlineData("goblin")]
    [InlineData("dragon")]
    [InlineData("12345")]
    [InlineData("¤#@429")]
    [InlineData("--help")]
    public void Parse_WithInvalidRace_ReturnsFailure(string arg)
    {
        // Arrange & Act
        var args = new[] { arg };
        var result = CommandLineParser.Parse(args);

        // Assert
        Assert.IsType<CommandLineParser.ParseResult.Failure>(result);
        var failure = (CommandLineParser.ParseResult.Failure)result;
        Assert.NotEmpty(failure.Message);
    }

    [Fact]
    public void Parse_WithNoArguments_ReturnsFailure()
    {
        // Arrange & Act
        string[] args = [];

        var result = CommandLineParser.Parse(args);

        // Assert
        Assert.IsType<CommandLineParser.ParseResult.Failure>(result);
        var failure = (CommandLineParser.ParseResult.Failure)result;
        Assert.NotEmpty(failure.Message);
    }
}
