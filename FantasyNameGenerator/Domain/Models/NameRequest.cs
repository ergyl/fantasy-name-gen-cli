namespace FantasyNameGenerator.Domain.Models;

public record NameRequest(
    Race Race,
    Gender Gender,
    Length Length,
    int NumberOfNames,
    long? Seed);

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