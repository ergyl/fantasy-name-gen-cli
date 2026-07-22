namespace FantasyNameGenerator.Presentation.CommandLine;

public record CliRequest
{
    public required string Race { get; init; }

    public bool Male { get; init; }

    public bool Female { get; init; }

    public bool Short { get; init; }

    public bool Full { get; init; }

    public int NumberOfNames { get; init; }

    public long? Seed { get; init; }
}