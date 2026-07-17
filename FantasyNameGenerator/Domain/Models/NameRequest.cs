namespace FantasyNameGenerator.Domain.Models;

public enum Race
{
    Human,
    Dwarven,
    Orc,
    Elf,
}


public enum Gender
{
    Male,
    Female,
    Random
}

public enum Length
{
    Short,
    Long
}

public record NameRequest(
    Race Race,
    Length? Length = Length.Short,
    Gender? Gender = Gender.Random,
    int? NumberOfNames = 1,
    long? Seed = 12345);
